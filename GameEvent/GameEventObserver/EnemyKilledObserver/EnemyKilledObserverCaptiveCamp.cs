using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ӫ�۲�Enemy�����¼�
public class EnemyKilledObserverCaptiveCamp : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private CampSystem m_CampSystem = null;

    public EnemyKilledObserverCaptiveCamp(CampSystem theCampSystem)
    {
        m_CampSystem = theCampSystem;
    }

    // �趨�۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    // ֪ͨSubject������
    public override void Update()
    {
        // �ۼ�����10����ʱ��ʾ����Ӫ
        if (m_Subject.GetKilledCount() > 10)
            m_CampSystem.ShowCaptiveCamp();
    }
}
