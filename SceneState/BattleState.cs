using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : SceneState
{
    public BattleState(SceneStateController controller) : base(controller)
    {
        this.stateID = StateID.BattleScene;
    }

    public override void Act()
    {
        //游戏的逻辑
        PBaseDefenseGame.Instance.Update();
    }

    public override void DoAfterLeaving()
    {
        base.DoAfterLeaving();
        PBaseDefenseGame.Instance.Release();
    }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        PBaseDefenseGame.Instance.Initinal();
    }

    public override void Reason()
    {
        //游戏结束

        if (PBaseDefenseGame.Instance.ThisGameIsOver())
            m_controller.PerformTransition(Transition.Exit);
    }
}
