using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���Ա����õĻ�����ɫ��ֵ����
public abstract class BaseAttr
{
    public abstract int GetMaxHP();
    public abstract float GetMoveSpeed();
    public abstract string GetAttrName();
}

// ʵ�����Ա����õĻ�����ɫ��ֵ
public class CharacterBaseAttr : BaseAttr
{
    private int m_MaxHP;        // ���HPֵ
    private float m_MoveSpeed;  // Ŀǰ�ƶ��ٶ�
    private string m_AttrName;      // ��ֵ������	

    public CharacterBaseAttr(int MaxHP, float MoveSpeed, string AttrName)
    {
        m_MaxHP = MaxHP;
        m_MoveSpeed = MoveSpeed;
        m_AttrName = AttrName;
    }

    public override int GetMaxHP()
    {
        return m_MaxHP;
    }

    public override float GetMoveSpeed()
    {
        return m_MoveSpeed;
    }

    public override string GetAttrName()
    {
        return m_AttrName;
    }
}

// �ط���ɫ�Ļ�����ֵ
public class EnemyBaseAttr : CharacterBaseAttr
{
    public int m_InitCritRate;  // ������
    public EnemyBaseAttr(int MaxHP, float MoveSpeed, string AttrName, int CritRate) : base(MaxHP, MoveSpeed, AttrName)
    {
        m_InitCritRate = CritRate;
    }

    public virtual int GetInitCritRate()
    {
        return m_InitCritRate;
    }
}