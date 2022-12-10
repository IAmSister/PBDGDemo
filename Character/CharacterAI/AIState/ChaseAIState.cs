using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//׷��״̬
public class ChaseAIState : IAIState
{
    private ICharacter m_ChaseTarget = null; // ׷����Ŀ��

    private const float CHASE_CHECK_DIST = 0.2f; 
    private Vector3 m_ChasePosition = Vector3.zero;
    private bool m_bOnChase = false;

    public ChaseAIState(ICharacter ChaseTarget)
    {
        m_ChaseTarget = ChaseTarget;
    }


    // ����
    public override void Update(List<ICharacter> Targets)
    {
        // û��Ŀ��ʱ����Ϊ����
        if (m_ChaseTarget == null || m_ChaseTarget.IsKilled())
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        // �ڹ���Ŀ���,��Ϊ����
        if (m_CharacterAI.TargetInAttackRange(m_ChaseTarget))
        {
            m_CharacterAI.StopMove();
            m_CharacterAI.ChangeAIState(new AttackAIState(m_ChaseTarget));
            return;
        }

        // �Ѿ���׷��
        if (m_bOnChase)
        {
            // �ѵ���׷��Ŀ��,��Ŀ�겻��,��Ϊ����
            float dist = Vector3.Distance(m_ChasePosition, m_CharacterAI.GetPosition());
            if (dist < CHASE_CHECK_DIST)
                m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        // ��Ŀ���ƶ�
        m_bOnChase = true;
        m_ChasePosition = m_ChaseTarget.GetPosition();
        m_CharacterAI.MoveTo(m_ChasePosition);
    }

    // Ŀ�걻�Ƴ�
    public override void RemoveTarget(ICharacter Target)
    {
        if (m_ChaseTarget.GetGameObject().name == Target.GetGameObject().name)
            m_ChaseTarget = null;
    }
}
