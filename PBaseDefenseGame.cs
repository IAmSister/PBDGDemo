using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBaseDefenseGame
{
    private static PBaseDefenseGame _instance;
    public static PBaseDefenseGame Instance
    {
        get 
        { 
            if(_instance == null)
            {
                _instance = new PBaseDefenseGame();
            }
            return _instance;
        }
    }

    // ��������״̬
    private bool m_bGameOver = false;

    //��Ϸϵͳ
    private GameEventSystem m_GameEventSystem = null;//��Ϸ�¼�ϵͳ
    private CampSystem m_CampSystem = null;//��Ӫϵͳ
    private StageSystem m_StageSystem = null;// �ؿ�ϵͳ
    private CharacterSystem m_CharacterSystem = null;//��ɫ����ϵͳ
    private APSystem m_APSystem = null;//�ж���ϵͳ
    private AchievementSystem m_AchievementSystem = null;//�ɾ�ϵͳ

    //����
    private CampInfoUI m_CampInfoUI = null;//��Ӫ����
    private SoldierInfoUI m_SoldierInfoUI = null;//սʿ��Ѷ����
    private GameStateInfoUI m_GameStateInfoUI = null;//��Ϸ״̬����
    private GamePauseUI m_GamePauseUI = null;//��Ϸ��ͣ����

    //��ʼ��Ϸ������趨
    public void Initinal()
    {
        // ��������״̬
        m_bGameOver = false;
        //��Ϸϵͳ
        m_GameEventSystem = new GameEventSystem(this); //��Ϸ�¼�ϵͳ
        m_CampSystem = new CampSystem(this);//��Ӫϵͳ
        m_StageSystem = new StageSystem(this);// �ؿ�ϵͳ
        m_CharacterSystem = new CharacterSystem(this);//��ɫ����ϵͳ
        m_APSystem = new APSystem(this);//�ж���ϵͳ
        m_AchievementSystem = new AchievementSystem(this); //�ɾ�ϵͳ
        //ע�ᵽ����ϵͳ
        m_CampInfoUI = new CampInfoUI(this);//��Ӫ��Ѷ
        m_SoldierInfoUI = new SoldierInfoUI(this);//Soldier��Ѷ
        m_GameStateInfoUI = new GameStateInfoUI(this);  // ��Ϸ����
        m_GamePauseUI = new GamePauseUI(this);	//��Ϸ��ͣ

        //ע�뵽����ϵͳ
        EnemyAI.SetStageSystem(m_StageSystem);

        //����浵
        LoadData();

        //ע����Ϸ�¼�ϵͳ
        RegisterGameEvent();
    }

    //ע����Ϸ�¼�ϵͳ
    private void RegisterGameEvent()
    {
        //�¼�ע��
        m_GameEventSystem.RegisterObserver(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverUI(this));
    }

    //ȡ�ش浵
    private AchievementSaveData LoadData()
    {
        AchievementSaveData OldData = new AchievementSaveData();
        OldData.LoadData();
        m_AchievementSystem.SetSaveData(OldData);
        return OldData;
    }

    //�ͷ���Ϸϵͳ
    public void Release()
    {
        //��Ϸϵͳ
        m_GameEventSystem.Release();
        m_CampSystem.Release();
        m_StageSystem.Release();
        m_CharacterSystem.Release();
        m_APSystem.Release();
        m_AchievementSystem.Release();
        //����
        m_CampInfoUI.Release();
        m_SoldierInfoUI.Release();
        m_GameStateInfoUI.Release();
        m_GamePauseUI.Release();
        UITool.ReleaseCanvas();
        //�浵
        SaveData();
    }
    // ��ʾ��ͣ
    public void GamePause()
    {
        if (m_GamePauseUI.IsVisible() == false)
            m_GamePauseUI.ShowGamePause(m_AchievementSystem.CreateSaveData());
        else
            m_GamePauseUI.Hide();
    }
    //�浵
    private void SaveData()
    {
        AchievementSaveData SaveData = m_AchievementSystem.CreateSaveData();
        SaveData.SaveData();
    }

    //����
    public void Update()
    {
        //�������
        InputProcess();
        //��Ϸϵͳ����
        m_GameEventSystem.Update();
        m_CampSystem.Update();
        m_StageSystem.Update();
        m_CharacterSystem.Update();
        m_APSystem.Update();
        m_AchievementSystem.Update();
        //��ҽ������
        m_CampInfoUI.Update();
        m_SoldierInfoUI.Update();
        m_GameStateInfoUI.Update();
        m_GamePauseUI.Update();
    }

    //�������
    private void InputProcess()
    {
        //  Mouse���
        if (Input.GetMouseButtonUp(0) == false)
            return;

        //�����������һ������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        // �߷�ÿһ����Hit����GameObject
        foreach (RaycastHit hit in hits)
        {
            // �Ƿ��б�Ӫ���
            CampOnClick CampClickScript = hit.transform.gameObject.GetComponent<CampOnClick>();
            if (CampClickScript != null)
            {
                CampClickScript.OnClick();
                return;
            }

            // �Ƿ��н�ɫ���
            SoldierOnClick SoldierClickScript = hit.transform.gameObject.GetComponent<SoldierOnClick>();
            if (SoldierClickScript != null)
            {
                SoldierClickScript.OnClick();
                return;
            }
        }
    }
    
    // ��Ϸ״̬
    public bool ThisGameIsOver()
    {
        return m_bGameOver;
    }
    // ����Soldier
    public void AddSoldier(ISoldier theSoldier)
    {
        if (m_CharacterSystem != null)
            m_CharacterSystem.AddSoldier(theSoldier);
    }
    // �Ƴ�Soldier
    public void RemoveSoldier(ISoldier theSoldier)
    {
        if (m_CharacterSystem != null)
            m_CharacterSystem.RemoveSoldier(theSoldier);
    }
    // ����Enemy
    public void AddEnemy(IEnemy theEnemy)
    {
        if (m_CharacterSystem != null)
            m_CharacterSystem.AddEnemy(theEnemy);
    }

    // �Ƴ�Enemy
    public void RemoveEnemy(IEnemy theEnemy)
    {
        if (m_CharacterSystem != null)
            m_CharacterSystem.RemoveEnemy(theEnemy);
    }
    // �ص����˵�
    public void ChangeToMainMenu()
    {
        m_bGameOver = true;
    }
    //��ʾSoldier��Ѷ
    public void ShowSoldierInfo(ISoldier Soldier)
    {
        m_SoldierInfoUI.ShowInfo(Soldier);
        m_CampInfoUI.Hide();
    }
    //  ��ϷѶϢ
    public void ShowGameMsg(string Msg)
    {
        m_GameStateInfoUI.ShowMsg(Msg);
    }
    // ��ʾ��Ӫ��Ѷ
    public void ShowCampInfo(ICamp Camp)
    {
        m_CampInfoUI.ShowInfo(Camp);
        m_SoldierInfoUI.Hide();
    }
    // ע����Ϸ�¼�
    public void RegisterGameEvent(ENUM_GameEvent emGameEvent, IGameEventObserver Observer)
    {
        m_GameEventSystem.RegisterObserver(emGameEvent, Observer);
    }
    // Ŀǰ��������
    public int GetEnemyCount()
    {
        if (m_CharacterSystem != null)
            return m_CharacterSystem.GetEnemyCount();
        return 0;
    }
    // ���ӵ�����������(��͸��GameEventSystem����) 
    public void AddEnemyKilledCount()
    {
        m_StageSystem.AddEnemyKilledCount();
    }
    // ��ʾHeart
    public void ShowHeart(int Value)
    {
        m_GameStateInfoUI.ShowHeart(Value);
        ShowGameMsg("��Ӫ������");
    }

    // ��ʾ�ؿ�
    public void ShowNowStageLv(int Lv)
    {
        m_GameStateInfoUI.ShowNowStageLv(Lv);
    }

    // ֪ͨ��Ϸ�¼�
    public void NotifyGameEvent(ENUM_GameEvent emGameEvent, System.Object Param)
    {
        m_GameEventSystem.NotifySubject(emGameEvent, Param);
    }

    // ִ�н�ɫϵͳ��Visitor
    public void RunCharacterVisitor(ICharacterVisitor Visitor)
    {
        m_CharacterSystem.RunVisitor(Visitor);
    }
    // ֪ͨAP���
    public void APChange(int NowAP)
    {
        m_GameStateInfoUI.ShowAP(NowAP);
    }

    // ����AP
    public bool CostAP(int ApValue)
    {
        return m_APSystem.CostAP(ApValue);
    }

}