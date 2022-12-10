using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����״̬
public class AttackAIState : IAIState
{
    private ICharacter m_AttackTarget = null; // ������Ŀ��

    public AttackAIState(ICharacter attackTarget)
    {
        m_AttackTarget = attackTarget;
    }

    //����
    public override void Update(List<ICharacter> Targets)
    {
        //û��Ŀ��ʱ����ΪIdle
        if(m_AttackTarget == null || m_AttackTarget.IsKilled() || Targets == null || Targets.Count == 0)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        //���ڹ���Ŀ���ڣ���Ϊ׷��
        if (m_CharacterAI.TargetInAttackRange(m_AttackTarget) == false)
        {
            m_CharacterAI.ChangeAIState(new ChaseAIState(m_AttackTarget));
            return;
        }

        // ����
        m_CharacterAI.Attack(m_AttackTarget);
    }

    //Ŀ�걻�Ƴ�
    public override void RemoveTarget(ICharacter Target)
    {
        if (m_AttackTarget.GetGameObject().name == Target.GetGameObject().name)
            m_AttackTarget = null;
    }
}
