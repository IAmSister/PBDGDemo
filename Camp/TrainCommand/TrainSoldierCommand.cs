using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ѵ��Soldier
public class TrainSoldierCommand : ITrainCommand
{
    ENUM_Soldier m_emSoldier;   // ����
    ENUM_Weapon m_emWeapon;     // ʹ�õ�����
    int m_Lv;           // �ȼ�
    Vector3 m_Position;     // ����λ��

    // ����
    public TrainSoldierCommand(ENUM_Soldier emSoldier, ENUM_Weapon emWeapon, int Lv, Vector3 Position)
    {
        m_emSoldier = emSoldier;
        m_emWeapon = emWeapon;
        m_Lv = Lv;
        m_Position = Position;
    }

    //ִ��
    public override void Execute()
    {
        //����Soldier
        ICharacterFactory Factory = PBDFactory.GetCharacterFactory();
        ISoldier Soldier = Factory.CreateSoldier(m_emSoldier, m_emWeapon, m_Lv, m_Position);

        // �����ʲ���ǰ�����
        int Rate = UnityEngine.Random.Range(0, 100);
        int AttrID = 0;
        if (Rate > 90)
            AttrID = 13;
        else if (Rate > 80)
            AttrID = 12;
        else if (Rate > 60)
            AttrID = 11;
        else
            return;

        // ������������
        //Debug.Log("����ǰ�����:"+AttrID);
        IAttrFactory AttrFactory = PBDFactory.GetAttrFactory();
        SoldierAttr PreAttr = AttrFactory.GetEliteSoldierAttr(ENUM_AttrDecorator.Prefix, AttrID, Soldier.GetSoldierValue());
        Soldier.SetCharacterAttr(PreAttr);
    }
}
