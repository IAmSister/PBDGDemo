using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI观测Enemy阵亡事件
public class EnemyKilledObserverUI : IGameEventObserver
{
    private EnemyKilledSubject m_Subject = null;
    private PBaseDefenseGame m_PBDGame = null;

    public EnemyKilledObserverUI(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    //设置观察的主题
    public override void SetSubject(IGameEventSubject Subject)
    {
        m_Subject = Subject as EnemyKilledSubject;
    }

    //通知更新
    public override void Update()
    {
        if (m_PBDGame != null)
            m_PBDGame.ShowGameMsg("敌方单位阵亡");
    }
}
