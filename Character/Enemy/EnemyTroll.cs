using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ɽ��
public class EnemyTroll : IEnemy
{
    public EnemyTroll()
    {
        m_emEnemyType = ENUM_Enemy.Troll;
        m_AssetName = "Enemy3";
        m_AttrID = 3;
        m_IconSpriteName = "OgreIcon";
    }

    // ������Ч
    public override void DoPlayHitSound()
    {
        //Debug.Log ("EnemyTroll.PlayHitSound");
    }

    // ������Ч
    public override void DoShowHitEffect()
    {
        PlayEffect("TrollHitEffect");
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitEnemyTroll(this);
    }
}
