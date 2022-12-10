using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Soldier����
public enum ENUM_Soldier
{
    Null = 0,
    Rookie = 1, // �±�
    Sergeant = 2,   // ��ʿ
    Captain = 3,    // ��ξ
    Captive = 4,    // ����
    Max,
}

//Soldier��ɫ����
public abstract class ISoldier : ICharacter
{
    protected ENUM_Soldier m_emSoldier = ENUM_Soldier.Null;
    protected int m_MedalCount = 0;  // ѫ����
    protected const int MAX_MEDAL = 3;  // ���ѫ����
    protected const int MEDAL_VALUE_ID = 20;// ѫ����ֵ��ʼֵ

    public ISoldier()
    {
    }

    public ENUM_Soldier GetSoldierType()
    {
        return m_emSoldier;
    }

    // ȡ��Ŀǰ�Ľ�ɫֵ
    public SoldierAttr GetSoldierValue()
    {
        return m_Attribute as SoldierAttr;
    }

    // ����������
    public override void UnderAttack(ICharacter Attacker)
    {
        // �����˺�ֵ
        m_Attribute.CalDmgValue(Attacker);

        // �Ƿ�����
        if (m_Attribute.GetNowHP() <= 0)
        {
            DoPlayKilledSound();    // ��Ч
            DoShowKilledEffect();   // ��Ч 
            Killed();           // ���
        }
    }

    // ����ѫ��
    public virtual void AddMedal()
    {
        if (m_MedalCount >= MAX_MEDAL)
            return;

        // ����ѫ��
        m_MedalCount++;
        // ȡ�ö�Ӧ��ѫ�¼ӳ�ֵ
        int AttrID = m_MedalCount + MEDAL_VALUE_ID;

        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();

        // ������β����
        SoldierAttr SufAttr = theAttrFactory.GetEliteSoldierAttr(ENUM_AttrDecorator.Suffix, AttrID, m_Attribute as SoldierAttr);
        SetCharacterAttr(SufAttr);
    }

    // ִ��Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitSoldier(this);
    }

    // ������Ч
    public abstract void DoPlayKilledSound();

    // ������Ч
    public abstract void DoShowKilledEffect();
}
