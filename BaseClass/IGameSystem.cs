using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏子系统公用界面
public abstract class IGameSystem
{
    protected PBaseDefenseGame m_PBDGame = null;
    public IGameSystem(PBaseDefenseGame pBDGame)
    {
        m_PBDGame = pBDGame;
    }

    public virtual void Initialize() { }
    public virtual void Update() { }
    public virtual void Release() { }
}
