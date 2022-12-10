using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ӫ����
public abstract class ICamp
{
    protected GameObject m_GameObject = null;
    protected string m_Name = "Null";//����
    protected string m_IconSpriteName = "";
    protected ENUM_Soldier m_emSoldier = ENUM_Soldier.Null;

    //ѵ������
    protected List<ITrainCommand> m_trainCommands = new List<ITrainCommand>();
    protected float m_CommandTimer = 0;//Ŀǰ��ȴʱ��
    protected float m_TrainCoolDown = 0;//��ȴʱ��

    //ѵ������
    protected ITrainCost m_TrainCost = null;

    //����Ϸ���棨��Ҫʱ�趨��
    protected PBaseDefenseGame m_PBDGame = null;

    protected ICamp(GameObject gameObject, float trainCoolDown, string name, string iconSpriteName)
    {
        m_GameObject = gameObject;
        m_Name = name;
        m_IconSpriteName = iconSpriteName;
        m_TrainCoolDown = trainCoolDown;
        m_CommandTimer = m_TrainCoolDown;
        m_TrainCost = new TrainCost();
    }

    //�趨����Ϸ����
    public void SetPBaseDefenseGame(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    //Ŀǰ
    public ENUM_Soldier GetSoldierType()
    {
        return m_emSoldier;
    }

    //����ѵ������
    public void AddTrainCommand(ITrainCommand Command)
    {
        m_trainCommands.Add(Command);
    }

    //ɾ��ѵ������
    public void RemoveLastTrainCommand()
    {
        if(m_trainCommands.Count == 0)
        {
            return;
        }
        //�Ƴ����һ��
        m_trainCommands.RemoveAt(m_trainCommands.Count- 1);
    }

    //Ŀǰѵ����������
    public int GetTrainCommandCount()
    {
        return m_trainCommands.Count;
    }

    //ִ������
    public void RunCommand()
    {
        //û�����ִ��
        if(m_trainCommands.Count == 0)
        {
            return;
        }
        //�ж���ȴʱ���Ƿ���
        m_CommandTimer -= Time.deltaTime;
        if(m_CommandTimer > 0)
        {
            return;
        }
        m_CommandTimer = m_TrainCoolDown;

        //ִ�е�һ������
        m_trainCommands[0].Execute();

        //�Ƴ�
        m_trainCommands.RemoveAt(0);
    }

    //�ȼ�
    public virtual int GetLevel()
    {
        return 0;
    }

    //��������
    public virtual int GetLevelUpCost()
    {
        return 0;
    }

    //����
    public virtual void LevelUp()
    {

    }

    //�����ȼ�
    public virtual ENUM_Weapon GetWeaponType()
    {
        return ENUM_Weapon.Null;
    }

    //������������
    public virtual int GetWeaponLevelUpCost()
    { 
        return 0;
    }

    //��������
    public virtual void WeaponLevelUp()
    {

    }

    //ѵ����
    public int GetOnTrainCount()
    {
        return m_trainCommands.Count;
    }

    //ѵ��timer
    public float GetTrainTimer()
    {
        return m_CommandTimer;
    }

    //����
    public string GetName()
    {
        return m_Name;
    }

    //icon����
    public string GetIconSpriteName()
    {
        return m_IconSpriteName;
    }

    //������ʾ
    public void SetVisible(bool bValue)
    {
        m_GameObject.SetActive(bValue);
    }

    //�Ƿ���ʾ
    public bool GetVisible()
    {
        return m_GameObject.activeSelf;
    }

    //ȡ��ѵ�����
    public abstract int GetTrainCost();

    //ѵ��
    public abstract void Train();
}
