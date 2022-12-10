using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//�����������Ľ�ɫ
public class CharacterSystem : IGameSystem
{
    private List<ICharacter> m_Soldiers = new List<ICharacter>();
    private List<ICharacter> m_Enemys = new List<ICharacter>();

    public CharacterSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {
        Initialize();

        // ע���¼�
        m_PBDGame.RegisterGameEvent(ENUM_GameEvent.NewStage, new NewStageObserverSoldierAddMedal(m_PBDGame));
    }

    #region ��ɫ����

    // ����Soldier
    public void AddSoldier(ISoldier theSoldier)
    {
        m_Soldiers.Add(theSoldier);
    }

    // �Ƴ�Soldier
    public void RemoveSoldier(ISoldier theSoldier)
    {
        m_Soldiers.Remove(theSoldier);
    }

    // ����Enemy
    public void AddEnemy(IEnemy theEnemy)
    {
        m_Enemys.Add(theEnemy);
    }

    // �Ƴ�Enemy
    public void RemoveEnemy(IEnemy theEnemy)
    {
        m_Enemys.Remove(theEnemy);
    }


    // �Ƴ���ɫ
    public void RemoveCharacter()
    {
        // �Ƴ����Ԅh���Ľ�ɫ
        RemoveCharacter(m_Soldiers, m_Enemys, ENUM_GameEvent.SoldierKilled);
        RemoveCharacter(m_Enemys, m_Soldiers, ENUM_GameEvent.EnemyKilled);
    }

    // �Ƴ���ɫ
    public void RemoveCharacter(List<ICharacter> Characters, List<ICharacter> Opponents, ENUM_GameEvent emEvent)
    {
        // �քeȡ�ÿ����Ƴ������Ľ�ɫ
        List<ICharacter> CanRemoves = new List<ICharacter>();
        foreach (ICharacter Character in Characters)
        {
            // �Ƿ�����
            if (Character.IsKilled() == false)
                continue;

            //  �Ƿ�ȷ�Ϲ���������
            if (Character.CheckKilledEvent() == false)
                m_PBDGame.NotifyGameEvent(emEvent, Character);

            // �Ƿ�����Ƴ�
            if (Character.CanRemove())
                CanRemoves.Add(Character);
        }

        // �Ƴ�
        foreach (ICharacter CanRemove in CanRemoves)
        {
            // ֪ͨ�����Ƴ�
            foreach (ICharacter Opponent in Opponents)
                Opponent.RemoveAITarget(CanRemove);

            // �ͷ���Դ���Ƴ�
            CanRemove.Release();
            Characters.Remove(CanRemove);
        }
    }

    // Enemy����
    UnitCountVisitor m_UnitCountVisitor = new UnitCountVisitor();
    public int GetEnemyCount()
    {
        // ʹ��Vistiror
        m_UnitCountVisitor.Reset();
        RunVisitor(m_UnitCountVisitor);
        return m_UnitCountVisitor.EnemyCount;

        // ֱ��ȡ��
        //return m_Enemys.Count;
    }

    // ִ��Visitor
    public void RunVisitor(ICharacterVisitor Visitor)
    {
        foreach (ICharacter Character in m_Soldiers)
            Character.RunVisitor(Visitor);
        foreach (ICharacter Character in m_Enemys)
            Character.RunVisitor(Visitor);
    }
    #endregion

    #region ����
    // ����
    public override void Update()
    {
        UpdateCharacter();
        UpdateAI(); // ����AI
    }

    // ���½�ɫ
    private void UpdateCharacter()
    {
        foreach (ICharacter Character in m_Soldiers)
            Character.Update();
        foreach (ICharacter Character in m_Enemys)
            Character.Update();
    }

    // ����AI
    private void UpdateAI()
    {
        // �քe��������Ⱥ���AI
        UpdateAI(m_Soldiers, m_Enemys);
        UpdateAI(m_Enemys, m_Soldiers);

        // �Ƴ���ɫ
        RemoveCharacter();
    }

    // ����AI
    private void UpdateAI(List<ICharacter> Characters, List<ICharacter> Targets)
    {
        foreach (ICharacter Character in Characters)
            Character.UpdateAI(Targets);
    }

    #endregion
}
