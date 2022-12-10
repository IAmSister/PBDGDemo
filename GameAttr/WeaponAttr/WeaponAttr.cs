using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//武器数值类别
public class WeaponAttr
{
    public int Atk { get; private set; }//攻击力
    public float AtkRange { get; private set; }//攻击距离
    public string AttrName { get; private set; }//属性名称

    public WeaponAttr(int atk, float atkRange, string attrName)
    {
        Atk = atk;
        AtkRange = atkRange;
        AttrName = attrName;
    }
}
