using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����Enemyʱ����Ĳ���
public class EnemyBuildParam : ICharacterBuildParam
{
    public Vector3 AttackPosition = Vector3.zero; // Ҫǰ����Ŀ��
    public EnemyBuildParam()
    {
    }
}
// Enemy����λ�Ľ���
public class EnemyBuilder : ICharacterBuilder
{
    private EnemyBuildParam m_BuildParam = null;

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParam = theParam as EnemyBuildParam;
    }

    // ����Asset�еĽ�ɫģ��
    public override void LoadAsset(int GameObjectID)
    {
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject EnemyGameObject = AssetFactory.LoadEnemy(m_BuildParam.NewCharacter.GetAssetName());
        EnemyGameObject.transform.position = m_BuildParam.SpawnPosition;
        EnemyGameObject.gameObject.name = string.Format("Enemy[{0}]", GameObjectID);
        m_BuildParam.NewCharacter.SetGameObject(EnemyGameObject);
    }

    // ����OnClickScript
    public override void AddOnClickScript()
    {
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
        // ȡ��Enemy����ֵ
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        int AttrID = m_BuildParam.NewCharacter.GetAttrID();
        EnemyAttr theEnemyAttr = theAttrFactory.GetEnemyAttr(AttrID);

        // �趨��ֵ�ļ������
        theEnemyAttr.SetAttStrategy(new EnemyAttrStrategy());

        // �趨����ɫ
        m_BuildParam.NewCharacter.SetCharacterAttr(theEnemyAttr);
    }

    // ����AI
    public override void AddAI()
    {
        EnemyAI theAI = new EnemyAI(m_BuildParam.NewCharacter, m_BuildParam.AttackPosition);
        m_BuildParam.NewCharacter.SetAI(theAI);
    }

    // ���������
    public override void AddCharacterSystem(PBaseDefenseGame PBDGame)
    {
        PBDGame.AddEnemy(m_BuildParam.NewCharacter as IEnemy);
    }
}
