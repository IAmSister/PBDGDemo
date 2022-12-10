using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ϸ����ֵ���� 
public abstract class IAttrFactory 
{
    //ȡ��Soldier����ֵ
    public abstract SoldierAttr GetSoldierAttr(int AttrID);

    //ȡ��Soldier����ֵ����������β�ļӳ�
    public abstract SoldierAttr GetEliteSoldierAttr(ENUM_AttrDecorator emType, int AttrID, SoldierAttr theSoldierAttr);

    // ȡ��Enemy����ֵ
    public abstract EnemyAttr GetEnemyAttr(int AttrID);

    // ȡ����������ֵ
    public abstract WeaponAttr GetWeaponAttr(int AttrID);

    // ȡ�üӳ��õ���ֵ
    public abstract AdditionalAttr GetAdditionalAttr(int AttrID);
}
