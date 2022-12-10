using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家角色AI
public class SoldierAI : ICharacterAI
{
    public SoldierAI(ICharacter character) : base(character)
    {
        //一开始的状态
        ChangeAIState(new IdleAIState());
    }

    //是否可以攻击Heart
    public override bool CanAttackHeart()
    {
        return false;
    }
}

