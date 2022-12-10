using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ�¼�
public enum ENUM_GameEvent
{
    Null = 0,
    EnemyKilled = 1,//�з���λ����
    SoldierKilled = 2,//��ҵ�λ����
    SoldierUpgate = 3,//��ҵ�λ����
    NewStage = 4,//�¹ؿ�
}

//��Ϸ�¼�ϵͳ
public class GameEventSystem : IGameSystem
{
    private Dictionary<ENUM_GameEvent, IGameEventSubject> m_GameEvents = new Dictionary<ENUM_GameEvent, IGameEventSubject>();
    public GameEventSystem(PBaseDefenseGame pBDGame) : base(pBDGame)
    {
        Initialize();
    }

    //�ͷ�
    public override void Release()
    {
        m_GameEvents.Clear();
    }

    //��ĳһ������ע��һ���۲���
    //EnemyKilled, EnemyKilledObserverCaptiveCamp EnemyKilledObserverStageScore
    //NewStage ��NewStageObserverSoldierAddMedal
    public void RegisterObserver(ENUM_GameEvent gameEvent,IGameEventObserver observer)
    {
        //ȡ���¼�
        //EnemyKilled EnemyKilledSubject
        IGameEventSubject subject = GetGameEventSubject(gameEvent);
        if (subject != null)
        {
            subject.Attach(observer);
            observer.SetSubject(subject);
        }
    }

    //ע��һ���¼�
    private IGameEventSubject GetGameEventSubject(ENUM_GameEvent gameEvent)
    {
        //�Ƿ��Ѿ�����
        if(m_GameEvents.ContainsKey(gameEvent))
        {
            return m_GameEvents[gameEvent];
        }

        //������Ӧ��GameEvent
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
                Debug.LogWarning("��û�����[" + gameEvent + "]ָ��Ҫ������Subject���");
                return null;
        }
        //������в��ش�
        m_GameEvents.Add(gameEvent, pSubject);
        return pSubject;
    }

    //֪ͨһ��GameEvent����
    public void NotifySubject(ENUM_GameEvent gameEvent,System.Object param)
    {
        //�Ƿ����
        if(!m_GameEvents.ContainsKey(gameEvent))
        {
            return;
        }
        m_GameEvents[gameEvent].SetParam(param);
    }
}