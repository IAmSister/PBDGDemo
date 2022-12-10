using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��Ϸ��ͣ
public class GamePauseUI : IUserInterface
{
    private Text m_EnemyKilledCountText = null;
    private Text m_SoldierKilledCountText = null;
    private Text m_StageLvCountText = null;
    public GamePauseUI(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();
    }

    public override void Initialize()
    {
        m_RootUI = UITool.FindUIGameObject("GamePauseUI");

        m_EnemyKilledCountText = UITool.GetUIComponent<Text>(m_RootUI, "EnemyKilledCountText");
        m_SoldierKilledCountText = UITool.GetUIComponent<Text>(m_RootUI, "SoldierKilledCountText");
        m_StageLvCountText = UITool.GetUIComponent<Text>(m_RootUI, "StageLvCountText");

        // Continue
        Button btn = UITool.GetUIComponent<Button>(m_RootUI, "ContinueBtn");
        btn.onClick.AddListener(OnContinueBtnClick);

        //Exit
        btn = UITool.GetUIComponent<Button>(m_RootUI, "ExitBtn");
        btn.onClick.AddListener(OnExitBtnClick);
        Hide();
    }
    public override void Hide()
    {
        Time.timeScale = 1;
        base.Hide();
    }
    public override void Show()
    {
        //��ʾ���ѶϢ
        Time.timeScale = 0;
        base.Show();
    }
    // ��ʾ��ͣ
    public void ShowGamePause(AchievementSaveData SaveData)
    {
        m_EnemyKilledCountText.text = string.Format("Ŀǰɱ�����ܺ�:{0}", SaveData.EnemyKilledCount);
        m_SoldierKilledCountText.text = string.Format("Ŀǰ�ҷ���λ�����ܺ�:{0}", SaveData.SoldierKilledCount);
        m_StageLvCountText.text = string.Format("��߹ؿ���:{0}", SaveData.StageLv);
        Show();
    }

    //Exit
    private void OnExitBtnClick()
    {
        Hide();
    }

    //Continue
    private void OnContinueBtnClick()
    {
        Hide();
        m_PBDGame.ChangeToMainMenu();
    }
}
