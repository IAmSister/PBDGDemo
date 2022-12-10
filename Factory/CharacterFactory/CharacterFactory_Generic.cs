using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ϸ��ɫ����(Generic��)
public class CharacterFactory_Generic : TCharacterFactory_Generic
{
    // ��ɫ����ָ����
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem(PBaseDefenseGame.Instance);

    // ����Soldier(Generice��)
    public ISoldier CreateSoldier<T>(ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition) where T : ISoldier, new()
    {
        // �a��Soldier�ą���
        SoldierBuildParam SoldierParam = new SoldierBuildParam();

        // �a��������Te
        SoldierParam.NewCharacter = new T();
        if (SoldierParam.NewCharacter == null)
            return null;

        // �O�����Å���
        SoldierParam.emWeapon = emWeapon;
        SoldierParam.SpawnPosition = SpawnPosition;
        SoldierParam.Lv = Lv;

        //  �a��������Builder���O������
        SoldierBuilder theSoldierBuilder = new SoldierBuilder();
        theSoldierBuilder.SetBuildParam(SoldierParam);

        // �a��
        m_BuilderDirector.Construct(theSoldierBuilder);
        return SoldierParam.NewCharacter as ISoldier;
    }

    // ����Enemy(Generice��)
    public IEnemy CreateEnemy<T>(ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition) where T : IEnemy, new()
    {
        // �a��Enemy�ą���
        EnemyBuildParam EnemyParam = new EnemyBuildParam();

        // �a��������Character
        EnemyParam.NewCharacter = new T();
        if (EnemyParam.NewCharacter == null)
            return null;

        // �O�����Å���
        EnemyParam.emWeapon = emWeapon;
        EnemyParam.SpawnPosition = SpawnPosition;
        EnemyParam.AttackPosition = AttackPosition;

        //  �a��������Builder���O������
        EnemyBuilder theEnemyBuilder = new EnemyBuilder();
        theEnemyBuilder.SetBuildParam(EnemyParam);

        // �a��
        m_BuilderDirector.Construct(theEnemyBuilder);
        return EnemyParam.NewCharacter as IEnemy;
    }
}
