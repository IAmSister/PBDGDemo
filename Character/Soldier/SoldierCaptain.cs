using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ξ
public class SoldierCaptain : ISoldier
{
    public SoldierCaptain()
    {
        m_emSoldier = ENUM_Soldier.Captain;
        m_AssetName = "Soldier3";
        m_IconSpriteName = "CaptainIcon";
        m_AttrID = 3;
    }

    // ������Ч
    public override void DoPlayKilledSound()
    {
        PlaySound("CaptainDeath");
    }

    // ������Ч
    public override void DoShowKilledEffect()
    {
        PlayEffect("CaptainDeadEffect");
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitSoldierCaptain(this);
    }
}
