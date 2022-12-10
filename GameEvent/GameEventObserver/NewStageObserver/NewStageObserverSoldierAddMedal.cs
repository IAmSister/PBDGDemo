using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����¹ؿ�-����Solderѫ��
public class NewStageObserverSoldierAddMedal : IGameEventObserver
{
    private NewStageSubject m_Subject = null;
    private PBaseDefenseGame m_PBDGame = null;

    public NewStageObserverSoldierAddMedal(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    // �趨�۲�����}
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as NewStageSubject;
    }

    // ֪ͨSubject������
    public override void Update()
    {
        // ����ѫ��
        SoldierAddMedalVisitor theAddMedalVisitor = new SoldierAddMedalVisitor(m_PBDGame);
        m_PBDGame.RunCharacterVisitor(theAddMedalVisitor);
    }
}
