using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻击状态
public class AttackAIState : IAIState
{
    private ICharacter m_AttackTarget = null; // 攻击的目标

    public AttackAIState(ICharacter attackTarget)
    {
        m_AttackTarget = attackTarget;
    }

    //更新
    public override void Update(List<ICharacter> Targets)
    {
        //没有目标时，改为Idle
        if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count == 0)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        //不在攻击目标内，改为追击
        if (m_CharacterAI.TargetInAttackRange(m_AttackTarget) == false)
        {
            m_CharacterAI.ChangeAIState(new ChaseAIState(m_AttackTarget));
            return;
        }

        // 攻击
        m_CharacterAI.Attack(m_AttackTarget);
    }

    //目标被移除
    public override void RemoveTarget(ICharacter Target)
    {
        if (m_AttackTarget.GetGameObject().name == Target.GetGameObject().name)
            m_AttackTarget = null;
    }
}
