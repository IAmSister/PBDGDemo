using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI状态界面
public abstract class IAIState
{
    protected ICharacterAI m_CharacterAI = null;//角色AI(状态的拥有者)

    public IAIState()
    {

    }

    //设定CharacterAI的对象
    public void SetCharacterAI(ICharacterAI characterAI)
    {
        m_CharacterAI = characterAI;
    }
    //设定要攻击的目标
    public virtual void SetAttackPosition(Vector3 AttackPosition)
    { 

    }

    // 更新
    public abstract void Update(List<ICharacter> Targets);

    // 目标被移除
    public virtual void RemoveTarget(ICharacter Target)
    {

    }
}
