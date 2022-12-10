using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�µĹؿ�
public class NewStageSubject : IGameEventSubject
{
    private int m_StageCount = 1;

    public NewStageSubject()
    { }

    // Ŀǰ�ؿ���
    public int GetStageCount()
    {
        return m_StageCount;
    }

    // ֪ͨ
    public override void SetParam(System.Object Param)
    {
        base.SetParam(Param);
        m_StageCount = (int)Param;

        // ֪ͨ
        Notify();
    }
}
