using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��Ӫ����
public class CampInfoUI : IUserInterface
{
    private ICamp m_Camp = null;//��ʾ�ı�Ӫ

    //�������
    private Button m_LevelUpBtn = null;
    private Button m_WeaponLvUpBtn = null;
    private Button m_TrainBtn = null;
    private Button m_CancelBtn = null;
    private Text m_AliveCountTxt = null;
    private Text m_CampLvTxt = null;
    private Text m_WeaponLvTxt = null;
    private Text m_TrainCostTxt = null;
    private Text m_TrainTimerTxt = null;
    private Text m_OnTrainCountTxt = null;
    private Text m_CampNameTxt = null;
    private Image m_CampImage = null;

    private UnitCountVisitor m_UnitCountVisitor = new UnitCountVisitor(); //��λ����

    public CampInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    //��ʼ
    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("CampInfoUI");

        //��ʾ��ѶϢ
        //��Ӫ����
        m_CampNameTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampNameText");
        //��Ӫͼ
        m_CampImage = UITool.GetUIComponent<Image>(m_RootUI, "CampIcon");
        //��λ��
        m_AliveCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "AliveCountText");
        //�ȼ�
        m_CampLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "CampLevelText");
        //�����ȼ�
        m_WeaponLvTxt = UITool.GetUIComponent<Text>(m_RootUI, "WeaponLevelText");
        //ѵ���е�����
        m_OnTrainCountTxt = UITool.GetUIComponent<Text>(m_RootUI, "OnTrainCountText");
        // ѵ������
        m_TrainCostTxt = UITool.GetUIComponent<Text>(m_RootUI, "TrainCostText");
        // ѵ��ʱ��
        m_TrainTimerTxt = UITool.GetUIComponent<Text>(m_RootUI, "TrainTimerText");

        // ��ҵĻ���
        // ����
        m_LevelUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "CampLevelUpBtn");
        m_LevelUpBtn.onClick.AddListener(OnLevelUpBtnClick);
        // ��������
        m_WeaponLvUpBtn = UITool.GetUIComponent<Button>(m_RootUI, "WeaponLevelUpBtn");
        m_WeaponLvUpBtn.onClick.AddListener(OnWeaponLevelUpBtnClick);
        // ѵ��
        m_TrainBtn = UITool.GetUIComponent<Button>(m_RootUI, "TrainSoldierBtn");
        m_TrainBtn.onClick.AddListener(OnTrainBtnClick);
        // ȡ��ѵ��
        m_CancelBtn = UITool.GetUIComponent<Button>(m_RootUI, "CancelTrainBtn");
        m_CancelBtn.onClick.AddListener(OnCancelBtnClick);

        Hide();
    }
    // ����
    public override void Update()
    {
        ShowOnTrainInfo();
    }

    //��ʾ��Ѷ
    public void ShowInfo(ICamp camp)
    {
        Show();
        m_Camp = camp;

        //����
        m_CampNameTxt.text = m_Camp.GetName();
        //ѵ������
        m_TrainCostTxt.text = string.Format("AP:{0}", m_Camp.GetTrainCost());

        // ѵ������Ѷ
        ShowOnTrainInfo();
        // Icon
        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        m_CampImage.sprite = Factory.LoadSprite(m_Camp.GetIconSpriteName());

        // ��������
        if (m_Camp.GetLevel() <= 0)
            EnableLevelInfo(false);
        else
        {
            EnableLevelInfo(true);
            m_CampLvTxt.text = string.Format("�ȼ�:" + m_Camp.GetLevel());
            ShowWeaponLv();// ��ʾ�����ȼ�
        }
    }


    //ѵ���е���Ѷ
    private void ShowOnTrainInfo()
    {
        if (m_Camp == null)
            return;
        int Count = m_Camp.GetOnTrainCount();
        m_OnTrainCountTxt.text = string.Format("ѵ������:" + Count);
        if (Count > 0)
            m_TrainTimerTxt.text = string.Format("���ʱ��:{0:0.00}", m_Camp.GetTrainTimer());
        else
            m_TrainTimerTxt.text = "";

        // ��λ
        m_UnitCountVisitor.Reset();
        m_PBDGame.RunCharacterVisitor(m_UnitCountVisitor);
        int UnitCount = m_UnitCountVisitor.GetUnitCount(m_Camp.GetSoldierType());
        m_AliveCountTxt.text = string.Format("��λ:{0}", UnitCount);
    }

    //��ʾ�����ȼ�
    private void ShowWeaponLv()
    {
        string WeaponName = "";
        switch (m_Camp.GetWeaponType())
        {
            case ENUM_Weapon.Gun:
                WeaponName = "ǹ";
                break;
            case ENUM_Weapon.Rifle:
                WeaponName = "��ǹ";
                break;
            case ENUM_Weapon.Rocket:
                WeaponName = "���Ͳ";
                break;
            default:
                WeaponName = "δ����";
                break;
        }
        m_WeaponLvTxt.text = string.Format("�����ȼ�:{0}", WeaponName);

    }

    // ��ʾ��ϸ��Ѷ
    private void EnableLevelInfo(bool Value)
    {
        m_CampLvTxt.enabled = Value;
        m_WeaponLvTxt.enabled = Value;
        m_LevelUpBtn.gameObject.SetActive(Value);
        m_WeaponLvUpBtn.gameObject.SetActive(Value);
    }

    // ȡ��ѵ��
    private void OnCancelBtnClick()
    {
        // ȡ��ѵ������
        m_Camp.RemoveLastTrainCommand();
        ShowInfo(m_Camp);
    }

    //ѵ��
    private void OnTrainBtnClick()
    {
        int Cost = m_Camp.GetTrainCost();
        if (CheckRule(Cost > 0, "�޷�ѵ��") == false)
            return;

        // �Ƿ��㹻
        string Msg = string.Format("AP�����޷�����,��Ҫ{0}��AP", Cost);
        if (CheckRule(m_PBDGame.CostAP(Cost), Msg) == false)
            return;

        // ����ѵ������
        m_Camp.Train();
        ShowInfo(m_Camp);
    }

    //��������
    private void OnWeaponLevelUpBtnClick()
    {
        int Cost = m_Camp.GetWeaponLevelUpCost();
        if (CheckRule(Cost > 0, "�Ѵ���ߵȼ�") == false)
            return;

        // �Ƿ��㹻
        string Msg = string.Format("AP�����޷�����,��Ҫ{0}��AP", Cost);
        if (CheckRule(m_PBDGame.CostAP(Cost), Msg) == false)
            return;

        // ����
        m_Camp.WeaponLevelUp();
        ShowInfo(m_Camp);
    }

    //����
    private void OnLevelUpBtnClick()
    {
        int Cost = m_Camp.GetLevelUpCost();
        if (CheckRule(Cost > 0, "�Ѵ���ߵȼ�") == false)
            return;

        // �Ƿ����㹻
        string Msg = string.Format("AP�����޷�����,��Ҫ{0}��AP", Cost);
        if (CheckRule(m_PBDGame.CostAP(Cost), Msg) == false)
            return;

        // ����
        m_Camp.LevelUp();
        ShowInfo(m_Camp);
    }
    //�ж���������ʾѶϢ
    private bool CheckRule(bool bValue, string NotifyMsg)
    {
        if (bValue == false)
            m_PBDGame.ShowGameMsg(NotifyMsg);
        return bValue;
    }
}
