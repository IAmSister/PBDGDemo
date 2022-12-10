using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierKilledSubject : IGameEventSubject
{
    private int m_KilledCount = 0;
    private ISoldier m_Soldier = null;

    public SoldierKilledSubject()
    { }

    // ȡ�ö���
    public ISoldier GetSoldier()
    {
        return m_Soldier;
    }

    // Ŀǰ�ҷ���λ������
    public int GetKilledCount()
    {
        return m_KilledCount;
    }

    // ֪ͨ�ҷ���λ����
    public override void SetParam(System.Object Param)
    {
        base.SetParam(Param);
        m_Soldier = Param as ISoldier;
        m_KilledCount++;

        // ֪ͨ
        Notify();
    }
}
