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

        // 設定成像
        SetGameObject(theSoldier.GetGameObject());

        // 將Soldier數值轉成Enemy用的
        EnemyAttr tempAttr = new EnemyAttr();
        SetCharacterAttr(tempAttr);

        // 設定武器
        SetWeapon(theSoldier.GetWeapon());

        // 更改為SoldierAI
        m_AI = new EnemyAI(this, AttackPos);
        m_AI.ChangeAIState(new IdleAIState());
    }

    // 播放音效
    public override void DoPlayHitSound()
    {
        m_Captive.DoPlayKilledSound();
    }

    // 播放特效
    public override void DoShowHitEffect()
    {
        m_Captive.DoShowKilledEffect();
    }

    // 執行Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        //
    }
}
