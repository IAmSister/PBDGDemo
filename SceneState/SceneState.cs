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
            Debug.LogError("不允许NullTransition"); return;
        }
        if (stateID == StateID.NullStateID)
        {
            Debug.LogError("不允许NullStateID"); return;
        }
        if (m_map.ContainsKey(transition))
        {
            Debug.LogError("添加转换条件的时候，" + transition + "已经存在于map中"); return;
        }
        m_map.Add(transition, stateID);
    }

    public void RemoveTransition(Transition transition) 
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("不允许NullTransition"); return;
        }
        if(!m_map.ContainsKey(transition))
        {
            Debug.LogError("删除转换条件的时候，" + transition + "不存在于map中"); return;
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
	/// 进入状态前的初始化
	/// </summary>
	public virtual void DoBeforeEntering() { }
    /// <summary>
    /// 离开此状态的清除
    /// </summary>
    public virtual void DoAfterLeaving() { }
    /// <summary>
    /// 实现的具体的逻辑
    /// </summary>
    public abstract void Act();
    /// <summary>
    /// 转换状态的条件判断
    /// </summary>
    public abstract void Reason();
    
}
