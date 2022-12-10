using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public enum Transition
{
    NullTransition = 0,
    CheckComplete,
    ClickBtn,
    Exit
}

public enum StateID
{
    NullStateID = 0,
    StartState = 1,
    MainMenuScene,
    BattleScene
}

public abstract class SceneState 
{
    protected StateID stateID;
    public StateID ID
    {
        get { return stateID; }
    }

    protected Dictionary<Transition,StateID> m_map = new Dictionary<Transition,StateID>();
    protected SceneStateController m_controller = null;

    public SceneState(SceneStateController controller)
    {
        this.m_controller = controller;
    }

    public void AddTransition(Transition transition, StateID stateID)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("������NullTransition"); return;
        }
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("������NullStateID"); return;
        }
        if (m_map.ContainsKey(transition))
        {
            Debug.LogError("���ת��������ʱ��" + transition + "�Ѿ�������map��"); return;
        }
        m_map.Add(transition, stateID);
    }

    public void RemoveTransition(Transition transition) 
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("������NullTransition"); return;
        }
        if(!m_map.ContainsKey(transition))
        {
            Debug.LogError("ɾ��ת��������ʱ��" + transition + "��������map��"); return;
        }
        m_map.Remove(transition);
    }

    public StateID GetOutputState(Transition transition)
    {
        if(m_map.ContainsKey(transition))
        {
            return m_map[transition];
        }
        return StateID.NullStateID;
    }
    /// <summary>
	/// ����״̬ǰ�ĳ�ʼ��
	/// </summary>
	public virtual void DoBeforeEntering() { }
    /// <summary>
    /// �뿪��״̬�����
    /// </summary>
    public virtual void DoAfterLeaving() { }
    /// <summary>
    /// ʵ�ֵľ�����߼�
    /// </summary>
    public abstract void Act();
    /// <summary>
    /// ת��״̬�������ж�
    /// </summary>
    public abstract void Reason();
    
}
