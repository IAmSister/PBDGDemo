using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ӫ
public class CaptiveCamp : ICamp
{
    private ENUM_Enemy m_emEnemy = ENUM_Enemy.Null;
    private Vector3 m_Position;

    // �趨��Ӫ�����ĵ�λ����ȴ
    public CaptiveCamp(GameObject theGameObject, ENUM_Enemy emEnemy, string CampName, string IconSprite, float TrainCoolDown, Vector3 Position) : base(theGameObject, TrainCoolDown, CampName, IconSprite)
    {
        m_emSoldier = ENUM_Soldier.Captive;
        m_emEnemy = emEnemy;
        m_Position = Position;
    }

    // ȡ��ѵ�����
    public override int GetTrainCost()
    {
        return 10;
    }

    // ѵ��Soldier
    public override void Train()
    {
        // ����һ��ѵ������
        TrainCaptiveCommand NewCommand = new TrainCaptiveCommand(m_emEnemy, m_Position, m_PBDGame);
        AddTrainCommand(NewCommand);
    }
}
