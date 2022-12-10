using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ����
public class EnemyOgre : IEnemy
{
    public EnemyOgre()
    {
        m_emEnemyType = ENUM_Enemy.Ogre;
        m_AssetName = "Enemy3";
        m_AttrID = 3;
        m_IconSpriteName = "OgreIcon";
    }

    // ������Ч
    public override void DoPlayHitSound()
    {
        //Debug.Log ("EnemyOgre.PlayHitSound");
    }

    // ������Ч
    public override void DoShowHitEffect()
    {
        PlayEffect("OgreHitEffect");
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitEnemyOgre(this);
    }
}
