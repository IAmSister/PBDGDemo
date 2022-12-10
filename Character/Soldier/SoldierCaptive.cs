using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����
public class SoldierCaptive : ISoldier
{
    private IEnemy m_Captive = null;
    public SoldierCaptive(IEnemy theEnemy)
    {
        m_emSoldier = ENUM_Soldier.Captive;
        m_Captive = theEnemy;

        // �趨����
        SetGameObject(theEnemy.GetGameObject());

        // ��Enemy��ֵת��Soldier�õ�
        SoldierAttr tempAttr = new SoldierAttr();
        tempAttr.SetSoldierAttr(theEnemy.GetCharacterAttr().GetBaseAttr());
        tempAttr.SetAttStrategy(theEnemy.GetCharacterAttr().GetAttStrategy());
        tempAttr.SetSoldierLv(1);   // �趨Ϊ1��
        SetCharacterAttr(tempAttr);

        //�趨����
        SetWeapon(theEnemy.GetWeapon());

        // ����ΪSoldierAI
        m_AI = new SoldierAI(this);
        m_AI.ChangeAIState(new IdleAIState());
    }

    //������Ч
    public override void DoPlayKilledSound()
    {
        m_Captive.DoPlayHitSound();
    }
    //������Ч
    public override void DoShowKilledEffect()
    {
        m_Captive.DoShowHitEffect();
    }
}
