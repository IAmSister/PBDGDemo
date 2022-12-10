using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Soldier����
public class SoldierInfoUI : IUserInterface
{
    private ISoldier m_Soldier = null; // ��ʾ��Soldier

    // ����Ԫ��
    private Image m_Icon = null;
    private Text m_NameTxt = null;
    private Text m_HPTxt = null;
    private Text m_LvTxt = null;
    private Text m_AtkTxt = null;
    private Text m_AtkRangeTxt = null;
    private Text m_SpeedTxt = null;
    private Slider m_HPSlider = null;
    public SoldierInfoUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    //��ʼ
    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("SoldierInfoUI");

        // ͼ��
        m_Icon = UITool.GetUIComponent<Image>(m_RootUI, "SoldierIcon");
        // ����
        m_NameTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierNameText");
        // HP
        m_HPTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierHPText");
        // �ȼ�
        m_LvTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierLvText");
        // Atk
        m_AtkTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierAtkText");
        // Atk ����
        m_AtkRangeTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierAtkRangeText");
        // Speed
        m_SpeedTxt = UITool.GetUIComponent<Text>(m_RootUI, "SoldierSpeedText");
        // HPͼʾ
        m_HPSlider = UITool.GetUIComponent<Slider>(m_RootUI, "SoldierSlider");

        //ע����Ϸ�¼�
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierKilled, new SoldierKilledObserverUI(this));
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.SoldierUpgate, new SoldierUpgateObserverUI(this));

        Hide();
    }

    public override void Hide()
    {
        base.Hide();
        m_Soldier = null;
    }

    //��ʾ��Ѷ
    public void ShowInfo(ISoldier soldier)
    {
        m_Soldier = soldier;
        if (m_Soldier == null || m_Soldier.IsKilled())
        {
            Hide();
            return;
        }
        Show();

        // ��ʾSoldier��Ѷ
        // Icon
        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        m_Icon.sprite = Factory.LoadSprite(m_Soldier.GetIconSpriteName());
        //����
        m_NameTxt.text = m_Soldier.GetName();
        //�ȼ� 
        m_LvTxt.text = string.Format("�ȼ�:{0}", m_Soldier.GetSoldierValue().GetSoldierLv());
        // Atk
        m_AtkTxt.text = string.Format("������:{0}", m_Soldier.GetWeapon().GetAtkValue());
        // Atk����
        m_AtkRangeTxt.text = string.Format("��������:{0}", m_Soldier.GetWeapon().GetAtkRange());
        // Speed
        m_SpeedTxt.text = string.Format("�ƶ��ٶ�:{0}", m_Soldier.GetSoldierValue().GetMoveSpeed()); ;

        // ����HP��Ѷ
        RefreshHPInfo();
    }
    // ����
    public void RefreshSoldier(ISoldier Soldier)
    {
        if (Soldier == null)
        {
            m_Soldier = null;
            Hide();
        }
        if (m_Soldier != Soldier)
            return;
        ShowInfo(Soldier);
    }

    // ����HP��Ѷ
    private void RefreshHPInfo()
    {
        int NowHP = m_Soldier.GetSoldierValue().GetNowHP();
        int MaxHP = m_Soldier.GetSoldierValue().GetMaxHP();

        m_HPTxt.text = string.Format("HP({0}/{1})", NowHP, MaxHP);
        // HPͼʾ
        m_HPSlider.maxValue = MaxHP;
        m_HPSlider.minValue = 0;
        m_HPSlider.value = NowHP;
    }

    // ����
    public override void Update()
    {
        base.Update();
        if (m_Soldier == null)
            return;
        // �Ƿ�����
        if (m_Soldier.IsKilled())
        {
            m_Soldier = null;
            Hide();
            return;
        }

        // ����HP�YӍ
        RefreshHPInfo();
    }
}
