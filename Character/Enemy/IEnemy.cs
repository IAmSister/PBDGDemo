using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy����
public enum ENUM_Enemy
{
    Null = 0,
    Elf = 1,// ����
    Troll = 2,// ɽ��
    Ogre = 3,// ����
    Catpive = 4,// ����
    Max,
}
//Enemy��ɫ����
public abstract class IEnemy : ICharacter
{
    protected ENUM_Enemy m_emEnemyType = ENUM_Enemy.Null;
    public IEnemy()
    { 
    }
    public ENUM_Enemy GetEnemyType()
    {
        return m_emEnemyType;
    }

    //����������
    public override void UnderAttack(ICharacter Attacker)
    {
        //�����˺�ֵ
        m_Attribute.CalDmgValue(Attacker);

        DoPlayHitSound();//��Ч
        DoShowHitEffect();//��Ч

        // �Ƿ�����
        if (m_Attribute.GetNowHP() <= 0)
        {
            Killed();
        }
    }

    // ������Ч
    public abstract void DoPlayHitSound();

    // ������Ч
    public abstract void DoShowHitEffect();

    // ִ��Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitEnemy(this);
    }
}
