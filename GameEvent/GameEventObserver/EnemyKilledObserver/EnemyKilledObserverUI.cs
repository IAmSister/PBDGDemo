using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�۲�Enemy�����¼�
public class EnemyKilledObserverUI : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private PBaseDefenseGame m_PBDGame = null;

    public EnemyKilledObserverUI(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    //���ù۲������
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    //֪ͨ����
    public override void Update()
    {
        if (m_PBDGame != null)
            m_PBDGame.ShowGameMsg("�з���λ����");
    }
}
