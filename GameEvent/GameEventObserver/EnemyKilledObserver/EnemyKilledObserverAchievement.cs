using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɾ�ȥ�۲�Enemy�����¼�
public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;
    public EnemyKilledObserverAchievement(AchievementSystem AchievementSystem)
    {
        m_AchievementSystem = AchievementSystem;
    }
    // �趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }
    // ֪ͨSubject������
    public override void Update()
    {
        m_AchievementSystem.AddEnemyKilledCount();
    }
}
