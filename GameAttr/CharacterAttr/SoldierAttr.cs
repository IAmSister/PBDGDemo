using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Soldier��ֵ
public class SoldierAttr : ICharacterAttr
{
    protected int m_SoldierLv; // Soldier�ȼ�
    protected int m_AddMaxHP; // ��ȼ�������HPֵ

    public SoldierAttr()
    { 

    }

    //�趨��ɫ��ֵ
    public void SetSoldierAttr(BaseAttr BaseAttr)
    {
        // ����Ԫ��
        base.SetBaseAttr(BaseAttr);

        // �ⲿ����
        m_SoldierLv = 1;
        m_AddMaxHP = 0;
    }
    //���õȼ�
    public void SetSoldierLv(int lv) 
    {
        m_SoldierLv = lv;
    }

    //ȡ�õȼ�
    public int GetSoldierLv() { return m_SoldierLv; }

    //���HP
    public override int GetMaxHP()
    {
        return base.GetMaxHP() + m_AddMaxHP;
    }

    //�趨���������������
    public void AddMaxHP(int AddMaxHP)
    {
        m_AddMaxHP = AddMaxHP;
    }
}
