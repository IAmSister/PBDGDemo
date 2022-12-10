using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɾ�ϵͳ
public class AchievementSystem : IGameSystem
{
    private AchievementSaveData m_LastSaveData = null; // ���һ�εĴ浵��Ѷ

    // ��¼�ĳɼ���Ŀ
    private int m_EnemyKilledCount = 0;
    private int m_SoldierKilledCount = 0;
    private int m_StageLv = 0;
    public AchievementSystem(PBaseDefenseGame pBDGame) : base(pBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        // ע����ع۲���
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverAchievement(this));
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverAchievement(this));
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.NewStage, new NewStageObserverAchievement(this));
    }

    // ����Enemy������
    public void AddEnemyKilledCount()
    {
        //Debug.Log ("AddEnemyKilledCount");
        m_EnemyKilledCount++;
    }

    // ����Soldier������
    public void AddSoldierKilledCount()
    {
        //Debug.Log ("AddSoldierKilledCount");
        m_SoldierKilledCount++;
    }

    // Ŀǰ�ؿ�
    public void SetNowStageLevel(int NowStageLevel)
    {
        //Debug.Log ("SetNowStageLevel");
        m_StageLv = NowStageLevel;
    }

    // �����浵
    public AchievementSaveData CreateSaveData()
    {
        AchievementSaveData SaveData = new AchievementSaveData();

        // �趨�µĸ߷���
        SaveData.EnemyKilledCount = Mathf.Max(m_EnemyKilledCount, m_LastSaveData.EnemyKilledCount);
        SaveData.SoldierKilledCount = Mathf.Max(m_SoldierKilledCount, m_LastSaveData.SoldierKilledCount);
        SaveData.StageLv = Mathf.Max(m_StageLv, m_LastSaveData.StageLv);

        return SaveData;
    }

    // �趨�ɵĴ浵
    public void SetSaveData(AchievementSaveData SaveData)
    {
        m_LastSaveData = SaveData;
    }
}
