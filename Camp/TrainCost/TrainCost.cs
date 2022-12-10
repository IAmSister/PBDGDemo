using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ѵ�����ü���
public class TrainCost : ITrainCost
{
    public TrainCost() { }
    public override int GetTrainCost(ENUM_Soldier emSoldier, int CampLv, ENUM_Weapon emWeapon)
    {
        int Cost = 0;
        // ���ݱ���
        switch (emSoldier)
        {
            case ENUM_Soldier.Rookie:
                Cost = 5;
                break;
            case ENUM_Soldier.Sergeant:
                Cost = 7;
                break;
            case ENUM_Soldier.Captain:
                Cost = 10;
                break;
            default:
                Debug.LogWarning("�]�ж��x[" + emSoldier + "]��Ӗ�����M");
                break;
        }

        // ��������
        switch (emWeapon)
        {
            case ENUM_Weapon.Gun:
                Cost += 5;
                break;
            case ENUM_Weapon.Rifle:
                Cost += 7;
                break;
            case ENUM_Weapon.Rocket:
                Cost += 10;
                break;
        }

        // �ӵȼ�
        Cost += (CampLv - 1) * 2;
        return Cost;
    }
}
