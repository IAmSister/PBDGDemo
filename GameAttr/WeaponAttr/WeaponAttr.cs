using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ֵ���
public class WeaponAttr
{
    public int Atk { get; private set; }//������
    public float AtkRange { get; private set; }//��������
    public string AttrName { get; private set; }//��������

    public WeaponAttr(int atk, float atkRange, string attrName)
    {
        Atk = atk;
        AtkRange = atkRange;
        AttrName = attrName;
    }
}
