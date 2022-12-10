using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//成就去观测Enemy阵亡事件
public class EnemyKilledObserverAchievement : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;
    public EnemyKilledObserverAchievement(AchievementSystem AchievementSystem)
    {
        m_AchievementSystem = AchievementSystem;
    }
    // 设定观察的主题
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }
    // 通知Subject被更新
    public override void Update()
    {
        m_AchievementSystem.AddEnemyKilledCount();
    }
}
