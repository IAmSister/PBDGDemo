using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ��ϵͳ���ý���
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
