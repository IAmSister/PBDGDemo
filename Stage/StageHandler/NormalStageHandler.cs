using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//һ��ؿ�
public class NormalStageHandler : IStageHandler
{
    // �趨�����͹ؿ�����
    public NormalStageHandler(IStageScore StateScore, IStageData StageData)
    {
        m_StageScore = StateScore;
        m_StatgeData = StageData;
    }
    //ȷ�Ϲؿ�
    public override IStageHandler CheckStage()
    {
        // �����Ƿ��㹻
        if (m_StageScore.CheckScore() == false)
            return this;

        // �Ѿ������һ����
        if (m_NextHandler == null)
            return this;

        //ȷ����һ���ؿ�
        return m_NextHandler.CheckStage();
    }

    public override bool IsFinished()
    {
        return m_StatgeData.IsFinished();
    }

    //��ʧ������ֵ
    public override int LoseHeart()
    {
        return 1;
    }

    public override void Reset()
    {
        m_StatgeData.Reset();
    }

    public override void Update()
    {
        m_StatgeData.Update();
    }
}
