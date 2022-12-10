using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<ENUM_Soldier, ICamp> m_SoldierCamps = new Dictionary<ENUM_Soldier, ICamp>();
    private Dictionary<ENUM_Enemy, ICamp> m_CaptiveCamps = new Dictionary<ENUM_Enemy, ICamp>(); 
    public CampSystem(PBaseDefenseGame pBDGame) : base(pBDGame)
    {
        Initialize();
    }

    //��ʼ��Ӫϵͳ
    public override void Initialize()
    {
        //����������Ӫ
        m_SoldierCamps.Add(ENUM_Soldier.Rookie, SoldierCampFactory(ENUM_Soldier.Rookie));
        m_SoldierCamps.Add(ENUM_Soldier.Sergeant, SoldierCampFactory(ENUM_Soldier.Sergeant));
        m_SoldierCamps.Add(ENUM_Soldier.Captain, SoldierCampFactory(ENUM_Soldier.Captain));
        

        // ����һ������Ӫ
        m_CaptiveCamps.Add(ENUM_Enemy.Elf, CaptiveCampFactory(ENUM_Enemy.Elf));
        // ע����Ϸ�¼��۲���
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.EnemyKilled, new EnemyKilledObserverCaptiveCamp(this));
    }

    // ����
    public override void Update()
    {
        // ��Ӫִ������
        foreach (SoldierCamp Camp in m_SoldierCamps.Values)
            Camp.RunCommand();
        foreach (CaptiveCamp Camp in m_CaptiveCamps.Values)
            Camp.RunCommand();
    }

    //ȡ�ó����еı�Ӫ
    private ICamp SoldierCampFactory(ENUM_Soldier emSoldier)
    {
        string GameObjectName = "SoldierCamp_";
        float CoolDown = 0;
        string CampName = "";
        string IconSprite = "";
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                GameObjectName += "Rookie";
                CoolDown = 3;
                CampName = "�����Ӫ";
                IconSprite = "RookieCamp";
                break;
            case ENUM_Soldier.Sergeant:
                GameObjectName += "Sergeant";
                CoolDown = 4;
                CampName = "��ʿ��Ӫ";
                IconSprite = "SergeantCamp";
                break;
            case ENUM_Soldier.Captain:
                GameObjectName += "Captain";
                CoolDown = 5;
                CampName = "��ξ��Ӫ";
                IconSprite = "CaptainCamp";
                break;
            default:
                Debug.Log("�]��ָ��[" + emSoldier + "]Ҫȡ�õĳ����������");
                break;
        }
        // ȡ�����
        GameObject theGameObject = UnityTool.FindGameObject(GameObjectName);

        // ȡ�ü��ϵ�
        Vector3 TrainPoint = GetTrainPoint(GameObjectName);

        // ������Ӫ
        SoldierCamp NewCamp = new SoldierCamp(theGameObject, emSoldier, CampName, IconSprite, CoolDown, TrainPoint);
        NewCamp.SetPBaseDefenseGame(m_PBDGame);

        // �O����Ӫʹ�õ�Script
        AddCampScript(theGameObject, NewCamp);

        return NewCamp;
    }

    // ��ʾ�����еķ���Ӫ
    public void ShowCaptiveCamp()
    {
        if (m_CaptiveCamps[ENUM_Enemy.Elf].GetVisible() == false)
        {
            m_CaptiveCamps[ENUM_Enemy.Elf].SetVisible(true);
            m_PBDGame.ShowGameMsg("�@�÷����I");
        }
    }
    // ȡ�ó����еķ���Ӫ
    private CaptiveCamp CaptiveCampFactory(ENUM_Enemy emEnemy)
    {
        string GameObjectName = "CaptiveCamp_";
        float CoolDown = 0;
        string CampName = "";
        string IconSprite = "";
        switch (emEnemy)
        {
            case ENUM_Enemy.Elf:
                GameObjectName += "Elf";
                CoolDown = 3;
                CampName = "�������Ӫ";
                IconSprite = "CaptiveCamp";
                break;
            default:
                Debug.Log("�]��ָ��[" + emEnemy + "]Ҫȡ�õĳ����������");
                break;

        }
        // ȡ�����
        GameObject theGameObject = UnityTool.FindGameObject(GameObjectName);

        // ȡ�ü��ϵ�
        Vector3 TrainPoint = GetTrainPoint(GameObjectName);

        // ������Ӫ
        CaptiveCamp NewCamp = new CaptiveCamp(theGameObject, emEnemy, CampName, IconSprite, CoolDown, TrainPoint);
        NewCamp.SetPBaseDefenseGame(m_PBDGame);

        // �趨��Ӫʹ�õ�Script
        AddCampScript(theGameObject, NewCamp);
        // ������
        NewCamp.SetVisible(false);

        // �ش�
        return NewCamp;
    }
    //ȡ�ü��ϵ�
    private Vector3 GetTrainPoint(string GameObjectName)
    {
        // ȡ�����
        GameObject theCamp = UnityTool.FindGameObject(GameObjectName);
        // ȡ�ü��ϵ�
        GameObject theTrainPoint = UnityTool.FindChildGameObject(theCamp, "TrainPoint");
        theTrainPoint.SetActive(false);

        return theTrainPoint.transform.position;
    }
    // �趨��Ӫʹ�õ�Script
    private void AddCampScript(GameObject theGameObject, ICamp Camp)
    {
        // ����Script
        CampOnClick CampScript = theGameObject.AddComponent<CampOnClick>();
        CampScript.theCamp = Camp;
    }
    // ֪ͨѵ��
    public void UTTrainSoldier(ENUM_Soldier emSoldier)
    {
        if (m_SoldierCamps.ContainsKey(emSoldier))
            m_SoldierCamps[emSoldier].Train();
    }
}
