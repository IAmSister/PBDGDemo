using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : SceneState
{
    public StartState(SceneStateController controller) : base(controller)
    {
        this.stateID = StateID.StartState;
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        //m_controller.SetState(new MainMenuState(m_Controller), "MainMenuScene");
        m_controller.PerformTransition(Transition.CheckComplete);
        
    }
    //½áÊø
    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
    }
    // ¿ªÊ¼
    public override void DoAfterLeaving()
    {
        base.DoAfterLeaving();
    }
}
