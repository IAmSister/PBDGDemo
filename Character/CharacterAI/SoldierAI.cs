using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ҽ�ɫAI
public class SoldierAI : ICharacterAI
{
    public SoldierAI(ICharacter character) : base(character)
    {
        //һ��ʼ��״̬
        ChangeAIState(new IdleAIState());
    }

    //�Ƿ���Թ���Heart
    public override bool CanAttackHeart()
    {
        return false;
    }
}

