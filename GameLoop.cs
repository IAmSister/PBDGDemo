using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸѭ��
public class GameLoop : MonoBehaviour
{
    //����״̬
    SceneStateController m_SceneStateController;

    private void Awake()
    {
        //��ת������ɾ��
        GameObject.DontDestroyOnLoad(this.gameObject);
        //���������
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
    }

    // Start is called before the first frame update
    void Start()
    {
        //�趨��ʼ�ĳ���
        InitState();
    }

    private void InitState()
    {
        m_SceneStateController = new SceneStateController();
        SceneState startState = new StartState(m_SceneStateController);
        startState.AddTransition(Transition.CheckComplete, StateID.MainMenuScene);
        SceneState mainMenuState = new MainMenuState(m_SceneStateController);
        mainMenuState.AddTransition(Transition.ClickBtn, StateID.BattleScene);
        SceneState battleState = new BattleState(m_SceneStateController);
        battleState.AddTransition(Transition.Exit, StateID.StartState);

        m_SceneStateController.AddState(startState);
        m_SceneStateController.AddState(mainMenuState);
        m_SceneStateController.AddState(battleState);
    }

    // Update is called once per frame
    void Update()
    {
        m_SceneStateController.Update();
    }
}
