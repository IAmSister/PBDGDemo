using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �±�
public class SoldierRookie : ISoldier
{
    public SoldierRookie()
    {
        m_emSoldier = ENUM_Soldier.Rookie;
        m_AssetName = "Soldier1";
        m_IconSpriteName = "RookieIcon";
        m_AttrID = 1;
    }

    // ������Ч
    public override void DoPlayKilledSound()
    {
        PlaySound("RookieDeath");
    }

    // ������Ч
    public override void DoShowKilledEffect()
    {
        PlayEffect("RookieDeadEffect");
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitSoldierRookie(this);
    }
}
