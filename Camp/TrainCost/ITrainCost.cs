using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ѵ�����ü���
public abstract class ITrainCost
{
    public abstract int GetTrainCost(ENUM_Soldier emSoldier, int CampLv, ENUM_Weapon emWeapon);
}

