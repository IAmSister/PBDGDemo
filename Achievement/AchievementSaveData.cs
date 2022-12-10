using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ɾͼ�¼�浵
public class AchievementSaveData
{
    //Ҫ�浵�ĳɾ���Ѷ
    public int EnemyKilledCount { get; set; }
    public int SoldierKilledCount { get; set; }
    public int StageLv { get; set; }

    public AchievementSaveData() { }

    public void SaveData()
    {
        PlayerPrefs.SetInt("EnemyKilledCount", EnemyKilledCount);
        PlayerPrefs.SetInt("SoldierKilledCount", SoldierKilledCount);
        PlayerPrefs.SetInt("StageLv", StageLv);
    }

    public void LoadData()
    {
        EnemyKilledCount = PlayerPrefs.GetInt("EnemyKilledCount", 0);
        SoldierKilledCount = PlayerPrefs.GetInt("SoldierKilledCount", 0);
        StageLv = PlayerPrefs.GetInt("StageLv", 0);
    }
}
