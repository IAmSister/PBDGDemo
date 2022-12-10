using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����״̬
public class IdleAIState : IAIState
{
    bool m_bSetAttackPosition = false;//�Ƿ������ù���Ŀ��

    public IdleAIState()
    {

    }

    //�趨Ҫ������Ŀ��
    public override void SetAttackPosition(Vector3 AttackPosition)
    {
        m_bSetAttackPosition = true;
    }

    //����
    public override void Update(List<ICharacter> Targets)
    {
        // �]��Ŀ��ʱ
        if (Targets == null || Targets.Count == 0)
        {
            // ���趨Ŀ��ʱ,��Ŀ���ƶ�
            if (m_bSetAttackPosition)
                m_CharacterAI.ChangeAIState(new MoveAIState());
            return;
        }

        // �ҳ������Ŀ��
        Vector3 NowPosition = m_CharacterAI.GetPosition();
        ICharacter theNearTarget = null;
        float MinDist = 999f;
        foreach (ICharacter Target in Targets)
        {
            // �Ѿ������Ĳ�����
            if (Target.IsKilled())
                continue;

            float dist = Vector3.Distance(NowPosition, Target.GetGameObject().transform.position);
            if (dist < MinDist)
            {
                MinDist = dist;
                theNearTarget = Target;
            }
        }

        // �]��Ŀ��,�᲻��
        if (theNearTarget == null)
            return;

        // �Ƿ��ھ�����
        if (m_CharacterAI.TargetInAttackRange(theNearTarget))
            m_CharacterAI.ChangeAIState(new AttackAIState(theNearTarget));
        else
            m_CharacterAI.ChangeAIState(new ChaseAIState(theNearTarget));
    }
}
