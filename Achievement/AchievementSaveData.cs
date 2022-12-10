using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//成就记录存档
public class AchievementSaveData
{
    //要存档的成就资讯
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
