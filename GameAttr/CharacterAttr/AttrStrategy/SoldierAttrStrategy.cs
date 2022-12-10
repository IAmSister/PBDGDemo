using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ҵ�λ��ʿ����
public class SoldierAttrStrategy : IAttrStrategy
{
    // ��ʼ����ֵ
    public override void InitAttr(ICharacterAttr CharacterAttr)
    {
        // �Ƿ�Ϊʿ�����
        SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;
        if (theSoldierAttr == null)
            return;

        // ����������еȼ��ӳ�
        int AddMaxHP = 0;
        int Lv = theSoldierAttr.GetSoldierLv();
        if (Lv > 0)
            AddMaxHP = (Lv - 1) * 2;

        // �趨���HP
        theSoldierAttr.AddMaxHP(AddMaxHP);
    }

    // �����ӳ�
    public override int GetAtkPlusValue(ICharacterAttr CharacterAttr)
    {
        // �]�й����ӳ�
        return 0;
    }

    // ȡ�ü��˺�ֵ
    public override int GetDmgDescValue(ICharacterAttr CharacterAttr)
    {
        // �Ƿ�Ϊʿ�����
        SoldierAttr theSoldierAttr = CharacterAttr as SoldierAttr;
        if (theSoldierAttr == null)
            return 0;

        // �ش�����ֵ
        return (theSoldierAttr.GetSoldierLv() - 1) * 2; 
    }

}
