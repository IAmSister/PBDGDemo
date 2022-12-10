using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�۲�Soldier�����¼�
public class SoldierUpgateObserverUI : IGameEventObserver
{
    private SoldierUpgateSubject m_Subject = null; // ���}
    private SoldierInfoUI m_InfoUI = null;	//  Ҫ֪ͨ�Ľ���
    
    public SoldierUpgateObserverUI(SoldierInfoUI InfoUI)
    {
        m_InfoUI = InfoUI; 
    }

    //�趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as SoldierUpgateSubject;
    }

    //// ֪ͨSubject������
    public override void Update()
    {
        // ֪ͨ�������
        m_InfoUI.RefreshSoldier(m_Subject.GetSoldier());
    }
}
