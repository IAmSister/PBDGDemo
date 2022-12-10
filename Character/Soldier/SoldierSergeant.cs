using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ��ʿ
public class SoldierSergeant : ISoldier
{
    public SoldierSergeant()
    {
        m_emSoldier = ENUM_Soldier.Sergeant;
        m_AssetName = "Soldier2";
        m_IconSpriteName = "SergeantIcon";
        m_AttrID = 2;
    }

    // ������Ч
    public override void DoPlayKilledSound()
    {
        PlaySound("SergeantDeath");
    }

    // ������Ч
    public override void DoShowKilledEffect()
    {
        PlayEffect("SergeantDeadEffect");
    }

    // ����Visitor
    public override void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitSoldierSergeant(this);
    }
}
