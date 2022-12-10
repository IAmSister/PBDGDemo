using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�۲�Soldier�����¼�
public class SoldierKilledObserverUI : IGameEventObserver
{
    private SoldierKilledSubject m_Subject = null; // ����
    private SoldierInfoUI m_InfoUI = null;	//  Ҫ֪ͨ�Ľ���

    public SoldierKilledObserverUI(SoldierInfoUI InfoUI)
    {
        m_InfoUI = InfoUI;
    }
    //�趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as SoldierKilledSubject;
    }

    // ֪ͨSubject������
    public override void Update()
    {
        // ֪ͨ�������
        m_InfoUI.RefreshSoldier(m_Subject.GetSoldier());
    }
}
