using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ɫ��ֵ����
public abstract class ICharacterAttr
{
    protected BaseAttr m_BaseAttr = null; 	// ������ɫ��ֵ

    protected int m_NowHP = 0; //ĿǰHPֵ
    protected IAttrStrategy m_AttrStrategy = null;//��ֵ�ļ������

    public ICharacterAttr() { }

    //�趨��������
    public void SetBaseAttr(BaseAttr baseAttr)
    {
        m_BaseAttr = baseAttr;
    }

    //ȡ�û�������
    public BaseAttr GetBaseAttr()
    {
        return m_BaseAttr;
    }

    //�趨��ֵ�ļ������
    public void SetAttStrategy(IAttrStrategy attStrategy)
    {
        m_AttrStrategy = attStrategy;
    }

    //ȡ����ֵ�ļ������
    public IAttrStrategy GetAttStrategy()
    {
        return m_AttrStrategy;
    }
    // ĿǰHP
    public int GetNowHP()
    {
        return m_NowHP;
    }

    // ���HP
    public virtual int GetMaxHP()
    {
        return m_BaseAttr.GetMaxHP();
    }

    // ����ĿǰHPֵ
    public void FullNowHP()
    {
        m_NowHP = GetMaxHP();
    }

    // �ƶ��ٶ�
    public virtual float GetMoveSpeed()
    {
        return m_BaseAttr.GetMoveSpeed();
    }

    // ȡ����ֵ����
    public virtual string GetAttrName()
    {
        return m_BaseAttr.GetAttrName();
    }

    // ��ʼ��ɫ��ֵ
    public virtual void InitAttr()
    {
        m_AttrStrategy.InitAttr(this);
        FullNowHP();
    }

    // �����ӳ�
    public int GetAtkPlusValue()
    {
        return m_AttrStrategy.GetAtkPlusValue(this);
    }

    // ȡ�ñ�������������˺�ֵ
    public void CalDmgValue(ICharacter Attacker)
    {
        // ȡ������������
        int AtkValue = Attacker.GetAtkValue();

        // ����
        AtkValue -= m_AttrStrategy.GetDmgDescValue(this);

        // ��ȥ�˺�
        m_NowHP -= AtkValue;
    }
}
