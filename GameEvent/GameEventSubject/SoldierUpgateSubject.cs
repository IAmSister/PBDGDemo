using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʿ������
public class SoldierUpgateSubject : IGameEventSubject
{
    private int m_UpgateCount = 0;
    private ISoldier m_Soldier = null;

    public SoldierUpgateSubject()
    { }

    // Ŀǰ��������
    public int GetUpgateCount()
    {
        return m_UpgateCount;
    }

    // ֪ͨSoldier��λ����
    public override void SetParam(System.Object Param)
    {
        base.SetParam(Param);
        m_Soldier = Param as ISoldier;
        m_UpgateCount++;

        // ֪ͨ
        Notify();
    }

    public ISoldier GetSoldier()
    {
        return m_Soldier;
    }
}
