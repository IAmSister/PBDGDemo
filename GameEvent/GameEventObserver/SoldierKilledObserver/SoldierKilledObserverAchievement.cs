using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɾ͹۲�Soldier�����¼�
public class SoldierKilledObserverAchievement : IGameEventObserver
{
    private SoldierKilledSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;
    public SoldierKilledObserverAchievement(AchievementSystem AchievementSystem)
    {
        m_AchievementSystem = AchievementSystem;
    }
    //�趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as SoldierKilledSubject;
    }
    // ֪ͨSubject������
    public override void Update()
    {
        m_AchievementSystem.AddSoldierKilledCount();
    }
}
