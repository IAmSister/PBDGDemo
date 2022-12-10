using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Solderѫ��
public class SoldierAddMedalVisitor : ICharacterVisitor
{
    PBaseDefenseGame m_PBDGame = null;

    public SoldierAddMedalVisitor(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    public override void VisitSoldier(ISoldier Soldier)
    {
        base.VisitSoldier(Soldier);
        Soldier.AddMedal();

        // ��Ϸ�¼�
        m_PBDGame.NotifyGameEvent(ENUM_GameEvent.SoldierUpgate, Soldier);
    }
}
