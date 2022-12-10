using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɾ͹۲��¹ؿ�
public class NewStageObserverAchievement : IGameEventObserver
{
    private NewStageSubject m_Subject = null;
    private AchievementSystem m_AchievementSystem = null;
    public NewStageObserverAchievement(AchievementSystem AchievementSystem)
    {
        m_AchievementSystem = AchievementSystem;
    }
    //�趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as NewStageSubject;
    }
    // ֪ͨSubject������
    public override void Update()
    {
        m_AchievementSystem.SetNowStageLevel(m_Subject.GetStageCount());
    }
}
