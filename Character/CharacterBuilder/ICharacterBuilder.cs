using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ɫʱ����Ĳ���
public abstract class ICharacterBuildParam
{
    public ENUM_Weapon emWeapon = ENUM_Weapon.Null;
    public ICharacter NewCharacter = null;
    public Vector3 SpawnPosition;
    public int AttrID;
    public string AssetName;
    public string IconSpriteName;
}

//������������ICharacter�ĸ����
public abstract class ICharacterBuilder
{
    // �趨��������
    public abstract void SetBuildParam(ICharacterBuildParam theParam);
    // ����Asset�еĽ�ɫģ��
    public abstract void LoadAsset(int GameObjectID);
    // ����OnClickScript
    public abstract void AddOnClickScript();
    // ��������
    public abstract void AddWeapon();
    // ����AI
    public abstract void AddAI();
    // �趨��ɫ����
    public abstract void SetCharacterAttr();
    // ���������
    public abstract void AddCharacterSystem(PBaseDefenseGame PBDGame);
}
