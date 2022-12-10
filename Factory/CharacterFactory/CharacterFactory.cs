using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ϸ��ɫ����
public class CharacterFactory : ICharacterFactory
{
    // ��ɫ����ָ����
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);
    //����Enemy
    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition)
    {
        // ����Enemy�Ĳ���
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        // ������Ӧ��Character
        switch (emEnemy)
        {
            case ENUM_Enemy.Elf:
                EnemyParam.NewCharacter = new EnemyElf();
                break;
            case ENUM_Enemy.Troll:
                EnemyParam.NewCharacter = new EnemyTroll();
                break;
            case ENUM_Enemy.Ogre:
                EnemyParam.NewCharacter = new EnemyOgre();
                break;
            default:
                Debug.LogWarning("�o������[" + emEnemy + "]");
                return null;
        }

        if (EnemyParam.NewCharacter == null)
            return null;

        // �趨���ò���
        EnemyParam.emWeapon = emWeapon;
        EnemyParam.SpawnPosition = SpawnPosition;
        EnemyParam.AttackPosition = AttackPosition;

        //  ������Ӧ��Builder���趨����
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        // ����
        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }
    //����Soldier
    public override ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition)
    {
        // ����Soldier�ą���
        SoldierBuildParam SoldierParam = new SoldierBuildParam();

        // ������Ӧ��Character
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                SoldierParam.NewCharacter = new SoldierRookie();
                break;
            case ENUM_Soldier.Sergeant:
                SoldierParam.NewCharacter = new SoldierSergeant();
                break;
            case ENUM_Soldier.Captain:
                SoldierParam.NewCharacter = new SoldierCaptain();
                break;
            default:
                Debug.LogWarning("CreateSoldier:�o������[" + emSoldier + "]");
                return null;
        }

        if (SoldierParam.NewCharacter == null)
            return null;

        // �趨���ò���
        SoldierParam.emWeapon = emWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = Lv;

        //  ������Ӧ��Builder���趨����
        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);

        // ����
        m_BuilderDirector.Construct(theSoldierBuilder);
        return SoldierParam.NewCharacter as ISoldier;
    }

   
}
