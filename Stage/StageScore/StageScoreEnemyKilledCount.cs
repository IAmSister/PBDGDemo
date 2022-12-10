using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ؿ�����ȷ�ϣ�����������
public class StageScoreEnemyKilledCount : IStageScore
{
    private int m_EnemyKilledCount = 0;
    private StageSystem m_StageSystem = null;

    public StageScoreEnemyKilledCount(int KilledCount, StageSystem theStageSystem)
    {
        m_EnemyKilledCount = KilledCount;
        m_StageSystem = theStageSystem;
    }

    //ȷ���ؿ������Ƿ���
    public override bool CheckScore()
    {
        return (m_StageSystem.GetEnemyKilledCount() >= m_EnemyKilledCount);
    }
}
