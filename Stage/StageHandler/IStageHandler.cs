using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ؿ�����
public abstract class IStageHandler
{
    protected IStageHandler m_NextHandler = null;// ��һ���ؿ�
    protected IStageData m_StatgeData = null;
    protected IStageScore m_StageScore = null;// �ؿ��ķ���

    // �趨��һ���ؿ�
    public IStageHandler SetNextHandler(IStageHandler NextHandler)
    {
        m_NextHandler = NextHandler;
        return m_NextHandler;
    }

    public abstract IStageHandler CheckStage();
    public abstract void Update();
    public abstract void Reset();
    public abstract bool IsFinished();
    public abstract int LoseHeart();
}
