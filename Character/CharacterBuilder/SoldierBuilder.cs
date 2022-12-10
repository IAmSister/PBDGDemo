using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����Soldierʱ����Ĳ���
public class SoldierBuildParam : ICharacterBuildParam
{
    public int Lv = 0;
    public SoldierBuildParam()
    {
    }
}

// Soldier����λ�Ľ���
public class SoldierBuilder : ICharacterBuilder
{
    private SoldierBuildParam m_BuildParam = null;

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as SoldierBuildParam;
    }

    // ����Asset�еĽ�ɫģ��
    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject SoldierGameObject = AssetFactory.LoadSoldier(m_BuildParam.NewCharacter.GetAssetName());
        SoldierGameObject.transform.position = m_BuildParam.SpawnPosition;
        SoldierGameObject.gameObject.name = string.Format("Soldier[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(SoldierGameObject);
    }

    // ����OnClickScript
    public override void AddOnClickScript()
    {
        SoldierOnClick Script = m_BuildParam.NewCharacter.GetGameObject().AddComponent<SoldierOnClick>();
        Script.Solder = m_BuildParam.NewCharacter as ISoldier;
    }

    // ��������
    public override void AddWeapon()
    {
        IWeaponFactory WeaponFactory = PBDFactory.GetWeaponFactory();
        IWeapon Weapon = WeaponFactory.CreateWeapon(m_BuildParam.emWeapon);

        // �趨����ɫ
        m_BuildParam.NewCharacter.SetWeapon(Weapon);
    }

    // �趨��ɫ����
    public override void SetCharacterAttr()
    {
        // ȡ��Soldier����ֵ
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        SoldierAttr theSoldierAttr = theAttrFactory.GetSoldierAttr(AttrID);

        // �趨
        theSoldierAttr.SetAttStrategy(new SoldierAttrStrategy());

        //  �趨�ȼ�
        theSoldierAttr.SetSoldierLv(m_BuildParam.Lv);

        //  �趨����ɫ
        m_BuildParam.NewCharacter.SetCharacterAttr(theSoldierAttr);
    }

    // ����AI
    public override void AddAI()
    {
        SoldierAI theAI = new SoldierAI(m_BuildParam.NewCharacter);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    // ���������
    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddSoldier(m_BuildParam.NewCharacter as ISoldier);
    }
}
