using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏事件
public enum ENUM_GameEvent
{
    Null = 0,
    EnemyKilled = 1,//敌方单位阵亡
    SoldierKilled = 2,//玩家单位阵亡
    SoldierUpgate = 3,//玩家单位升级
    NewStage = 4,//新关卡
}

//游戏事件系统
public class GameEventSystem : IGameSystem
{
    private Dictionary<ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary<ENUM_GameEvent, IGameEventSubject>();
    public GameEventSystem(PBaseDefenseGame pBDGame) : base(pBDGame)
    {
        Initialize();
    }

    //释放
    public override void Release()
    {
        m_GameEvents.Clear();
    }

    //替某一个主题注册一个观察者
    //EnemyKilled, EnemyKilledObserverCaptiveCamp EnemyKilledObserverStageScore
    //NewStage ，NewStageObserverSoldierAddMedal
    public void RegisterObserver(ENUM_GameEvent gameEvent,IGameEventObserver observer)
    {
        //取得事件
        //EnemyKilled EnemyKilledSubject
        IGameEventSubject subject = GetGameEventSubject(gameEvent);
        if (subject != null)
        {
            subject.Attach(observer);
            observer.SetSubject(subject);
        }
    }

    //注册一个事件
    private IGameEventSubject GetGameEventSubject(ENUM_GameEvent gameEvent)
    {
        //是否已经存在
        if(m_GameEvents.ContainsKey(gameEvent))
        {
            return m_GameEvents[gameEvent];
        }

        //产生对应的GameEvent
        IGameEventSubject pSubject = null;
        switch (gameEvent)
        {
            case ENUM_GameEvent.Null:
                break;
            case ENUM_GameEvent.EnemyKilled:
                pSubject = new EnemyKilledSubject();
                break;
            case ENUM_GameEvent.SoldierKilled:
                pSubject = new SoldierKilledSubject();
                break;
            case ENUM_GameEvent.SoldierUpgate:
                pSubject = new SoldierUpgateSubject();
                break;
            case ENUM_GameEvent.NewStage:
                pSubject = new NewStageSubject();
                break;
            default:
                Debug.LogWarning("还没有针对[" + gameEvent + "]指定要产生的Subject类别");
                return null;
        }
        //加入库中并回传
        m_GameEvents.Add(gameEvent, pSubject);
        return pSubject;
    }

    //通知一个GameEvent更新
    public void NotifySubject(ENUM_GameEvent gameEvent,System.Object param)
    {
        //是否存在
        if(!m_GameEvents.ContainsKey(gameEvent))
        {
            return;
        }
        m_GameEvents[gameEvent].SetParam(param);
    }
}