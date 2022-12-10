using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ϸ��ɫ��������
public abstract class ICharacterFactory
{
    // ����Soldier
    public abstract ISoldier CreateSoldier(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 SpawnPosition);

    // ����Enemy
    public abstract IEnemy CreateEnemy(ENUM_Enemy emEnemy, ENUM_Weapon emWeapon, Vector3 SpawnPosition, Vector3 AttackPosition);
}
