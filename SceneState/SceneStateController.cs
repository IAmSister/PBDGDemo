using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.VersionControl.Asset;

public class SceneStateController
{
    private Dictionary<StateID, SceneState> m_states = new Dictionary<StateID, SceneState>();

    private StateID m_currentStateID;
    private SceneState m_currentState;
    private bool m_bRunBegin = false;
    AsyncOperation async;
    public void Update()
    {
        if(async != null && !async.isDone)
        {
            return;
        }
        if(m_currentState != null && m_bRunBegin == false)
        {
            m_currentState.DoBeforeEntering();
            m_bRunBegin=true;
        }
        if(m_currentState != null)
        {
            m_currentState.Act();
            m_currentState.Reason();
        }
    }

    public void AddState(SceneState state)
    {
        if(state == null)
        {
            Debug.LogError("State不能为空"); return;
        }
        if(m_currentState == null)
        {
            m_currentState= state;
            m_currentStateID= state.ID;
        }
        if(m_states.ContainsKey(state.ID))
        {
            Debug.LogError("状态" + state.ID + "已经存在，无法重复添加"); return;
        }
        m_states.Add(state.ID, state);
    }

    public void RemoveState(StateID id)
    {
        if(id == StateID.NullStateID)
        {
            Debug.LogError("无法删除空状态"); return;
        }
        if (m_states.ContainsKey(id) == false)
        {
            Debug.LogError("无法删除不存在的状态：" + id); return;
        }
        m_states.Remove(id);
    }
    public void PerformTransition(Transition transition)
    {
        if (transition == Transition.NullTransition)
        {
            Debug.LogError("无法执行空的转换条件"); return;
        }
        StateID id = m_currentState.GetOutputState(transition);
        if (id == StateID.NullStateID)
        {
            Debug.LogWarning("当前状态" + m_currentStateID + "无法根据转换条件" + transition + "发生转换"); return;
        }
        if (m_states.ContainsKey(id) == false)
        {
            Debug.LogError("在状态机里面不存在状态" + id + "，无法进行状态转换！"); return;
        }
        m_bRunBegin = false;
        // 载入场景
        LoadScene(id);
        if (m_currentState != null)
            m_currentState.DoAfterLeaving();
        SceneState state = m_states[id];
        m_currentState = state;
        m_currentStateID = id;
    }

    private void LoadScene(StateID id)
    {
        async = SceneManager.LoadSceneAsync((int)id - 1);
    }
}
