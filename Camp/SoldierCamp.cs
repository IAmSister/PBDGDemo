using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Soldier��Ӫ
public class SoldierCamp : ICamp
{
    const int MAX_LV = 3;
    ENUM_Weapon m_emWeapon = ENUM_Weapon.Gun;   // �����ȼ�
    int m_Lv = 1;                               // ��Ӫ�ȼ�
    Vector3 m_Position;                         // ѵ����ɺ�ļ��ϵ�


    // �趨��Ӫ�����ĵ�λ����ȴ
    public SoldierCamp(GameObject gameObject,ENUM_Soldier emSoldier, string name, string iconSpriteName, float trainCoolDown,Vector3 Position) : base(gameObject, trainCoolDown, name, iconSpriteName )
    {
        m_emSoldier = emSoldier;
        m_Position = Position;
    }

    // �ȼ�
    public override int GetLevel()
    {
        return m_Lv;
    }

    // ��������
    public override int GetLevelUpCost()
    {
        if (m_Lv >= MAX_LV)
            return 0;
        return 100;
    }

    // ����
    public override void LevelUp()
    {
        m_Lv++;
        m_Lv = Mathf.Min(m_Lv, MAX_LV);
    }

    // �����ȼ�
    public override ENUM_Weapon GetWeaponType()
    {
        return m_emWeapon;
    }

    // ������������
    public override int GetWeaponLevelUpCost()
    {
        if ((m_emWeapon + 1) >= ENUM_Weapon.Max)
            return 0;
        return 100;
    }

    // ��������
    public override void WeaponLevelUp()
    {
        m_emWeapon++;
        if (m_emWeapon >= ENUM_Weapon.Max)
            m_emWeapon--;
    }

    // ȡ��ѵ�����
    public override int GetTrainCost()
    {
        return m_TrainCost.GetTrainCost(m_emSoldier, m_Lv, m_emWeapon);
    }

    // ѵ��Soldier
    public override void Train()
    {
        // ����һ��ѵ������
        TrainSoldierCommand NewCommand = new TrainSoldierCommand(m_emSoldier, m_emWeapon, m_Lv, m_Position);
        AddTrainCommand(NewCommand);
    }
}
