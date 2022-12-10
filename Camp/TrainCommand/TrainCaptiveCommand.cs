using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ѵ������
public class TrainCaptiveCommand : ITrainCommand
{
    private PBaseDefenseGame m_PBDGame = null;
    private ENUM_Enemy m_emEnemy; // ����
    private Vector3 m_Position; // ����λ��

    public TrainCaptiveCommand(ENUM_Enemy emEnemy, Vector3 Position, PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
        m_emEnemy = emEnemy;
        m_Position = Position;
    }

    public override void Execute()
    {
        //�Ȳ���Enemy
        ICharacterFactory factory = PBDFactory.GetCharacterFactory();
        IEnemy theEnemy = factory.CreateEnemy(m_emEnemy, ENUM_Weapon.Gun, m_Position, Vector3.zero);

        //�ٽ�������(ת����)
        SoldierCaptive soldierCaptive = new SoldierCaptive(theEnemy);

    }
}
