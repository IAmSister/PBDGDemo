using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuState : SceneState
{
    public MainMenuState(SceneStateController controller) : base(controller)
    {
        this.stateID = StateID.MainMenuScene;
    }

    public override void Act()
    {
        
    }

    public override void DoAfterLeaving()
    {
        base.DoAfterLeaving();
    }

    //¿ªÊ¼
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        GameObject parent = GameObject.Find("Canvas").gameObject;
        Button beginBtn = parent.transform.Find("StartGameBtn").GetComponent<Button>();
        if (beginBtn != null)
        {
            beginBtn.onClick.AddListener(OnStartGameBtnClick);
        }
    }

    private void OnStartGameBtnClick()
    {
        Debug.Log("µã»÷");
        m_controller.PerformTransition(Transition.ClickBtn);
    }

    public override void Reason()
    {
        
    }
}
