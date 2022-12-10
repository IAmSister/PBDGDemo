using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaptive : IEnemy
{
    private ISoldier m_Captive = null;

    // 
    public EnemyCaptive(ISoldier theSoldier, Vector3 AttackPos)
    {
        m_emEnemyType = ENUM_Enemy.Catpive;
        m_Captive = theSoldier;

        // �O������
        SetGameObject(theSoldier.GetGameObject());

        // ��Soldier��ֵ�D��Enemy�õ�
        EnemyAttr tempAttr = new EnemyAttr();
        SetCharacterAttr(tempAttr);

        // �O������
        SetWeapon(theSoldier.GetWeapon());

        // ���Ğ�SoldierAI
        m_AI = new EnemyAI(this, AttackPos);
        m_AI.ChangeAIState(new IdleAIState());
    }

    // ������Ч
    public override void DoPlayHitSound()
    {
        m_Captive.DoPlayKilledSound();
    }

    // ������Ч
    public override void DoShowHitEffect()
    {
        m_Captive.DoShowKilledEffect();
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        //
    }
}
