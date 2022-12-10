using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//产生游戏角色工厂(Generic版)
public class CharacterFactory_Generic : TCharacterFactory_Generic
{
    // 角色建立指導者
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);

    // 建立Soldier(Generice版)
    public ISoldier CreateSoldier<T>(ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition) where T : ISoldier, new()
    {
        // 產生Soldier的參數
        SoldierBuildParam SoldierParam = new SoldierBuildParam();

        // 產生對應的T類別
        SoldierParam.NewCharacter = new T();
        if (SoldierParam.NewCharacter == null)
            return null;

        // 設定共用參數
        SoldierParam.emWeapon = emWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = Lv;

        //  產生對應的Builder及設定參數
        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);

        // 產生
        m_BuilderDirector.Construct(theSoldierBuilder);
        return SoldierParam.NewCharacter as ISoldier;
    }

    // 建立Enemy(Generice版)
    public IEnemy CreateEnemy<T>(ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition) where T : IEnemy, new()
    {
        // 產生Enemy的參數
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        // 產生對應的Character
        EnemyParam.NewCharacter = new T();
        if (EnemyParam.NewCharacter == null)
            return null;

        // 設定共用參數
        EnemyParam.emWeapon = emWeapon;
        EnemyParam.SpawnPosition = SpawnPosition;
        EnemyParam.AttackPosition = AttackPosition;

        //  產生對應的Builder及設定參數
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        // 產生
        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }
}
