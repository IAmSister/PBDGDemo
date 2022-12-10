using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
public class EnemyElf : IEnemy
{
    public EnemyElf()
    {
        m_emEnemyType = ENUM_Enemy.Elf;
        m_AssetName = "Enemy1";
        m_AttrID = 1;
        m_IconSpriteName = "ElfIcon";
    }

    // ������Ч
    public override void DoPlayHitSound()
    {
        //Debug.Log ("EnemyElf.PlayHitSound");
    }

    // ������Ч
    public override void DoShowHitEffect()
    {
        PlayEffect("ElfHitEffect");
    }

    // ִ��Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitEnemyElf(this);
    }
}
