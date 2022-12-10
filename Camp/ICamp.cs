using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//兵营界面
public abstract class ICamp
{
    protected GameObject m_GameObject = null;
    protected string m_Name = "Null";//名称
    protected string m_IconSpriteName = "";
    protected ENUM_Soldier m_emSoldier = ENUM_Soldier.Null;

    //训练命令
    protected List<ITrainCommand> m_trainCommands = new List<ITrainCommand>();
    protected float m_CommandTimer = 0;//目前冷却时间
    protected float m_TrainCoolDown = 0;//冷却时间

    //训练花费
    protected ITrainCost m_TrainCost = null;

    //主游戏界面（必要时设定）
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

    //设定主游戏界面
    public void SetPBaseDefenseGame(PBaseDefenseGame PBDGame)
    {
        m_PBDGame = PBDGame;
    }

    //目前
    public ENUM_Soldier GetSoldierType()
    {
        return m_emSoldier;
    }

    //新增训练命令
    public void AddTrainCommand(ITrainCommand Command)
    {
        m_trainCommands.Add(Command);
    }

    //删除训练命令
    public void RemoveLastTrainCommand()
    {
        if(m_trainCommands.Count == 0)
        {
            return;
        }
        //移除最后一个
        m_trainCommands.RemoveAt(m_trainCommands.Count- 1);
    }

    //目前训练命令数量
    public int GetTrainCommandCount()
    {
        return m_trainCommands.Count;
    }

    //执行命令
    public void RunCommand()
    {
        //没有命令不执行
        if(m_trainCommands.Count == 0)
        {
            return;
        }
        //判断冷却时间是否到了
        m_CommandTimer -= Time.deltaTime;
        if(m_CommandTimer > 0)
        {
            return;
        }
        m_CommandTimer = m_TrainCoolDown;

        //执行第一个命令
        m_trainCommands[0].Execute();

        //移除
        m_trainCommands.RemoveAt(0);
    }

    //等级
    public virtual int GetLevel()
    {
        return 0;
    }

    //升级花费
    public virtual int GetLevelUpCost()
    {
        return 0;
    }

    //升级
    public virtual void LevelUp()
    {

    }

    //武器等级
    public virtual ENUM_Weapon GetWeaponType()
    {
        return ENUM_Weapon.Null;
    }

    //武器升级花费
    public virtual int GetWeaponLevelUpCost()
    { 
        return 0;
    }

    //武器升级
    public virtual void WeaponLevelUp()
    {

    }

    //训练数
    public int GetOnTrainCount()
    {
        return m_trainCommands.Count;
    }

    //训练timer
    public float GetTrainTimer()
    {
        return m_CommandTimer;
    }

    //名称
    public string GetName()
    {
        return m_Name;
    }

    //icon档名
    public string GetIconSpriteName()
    {
        return m_IconSpriteName;
    }

    //设置显示
    public void SetVisible(bool bValue)
    {
        m_GameObject.SetActive(bValue);
    }

    //是否显示
    public bool GetVisible()
    {
        return m_GameObject.activeSelf;
    }

    //取得训练金额
    public abstract int GetTrainCost();

    //训练
    public abstract void Train();
}
