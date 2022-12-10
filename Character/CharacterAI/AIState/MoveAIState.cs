using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ƶ���Ŀ��״̬
public class MoveAIState : IAIState
{
    private const float MOVE_CHECK_DIST = 1.5f; //
    bool m_bOnMove = false;
    Vector3 m_AttackPosition = Vector3.zero;

    public MoveAIState()
    {

    }

    //�趨Ҫ������Ŀ��
    public override void SetAttackPosition(Vector3 AttackPosition)
    {
        m_AttackPosition = AttackPosition;
    }

    //����
    public override void Update(List<ICharacter> Targets)
    {
        // ��Ŀ��ʱ,��Ϊ����״̬
        if (Targets != null && Targets.Count > 0)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        // �Ѿ�Ŀ���ƶ�
        if (m_bOnMove)
        {
            //  �Ƿ񵽴�Ŀ��
            float dist = Vector3.Distance(m_AttackPosition, m_CharacterAI.GetPosition());
            if (dist < MOVE_CHECK_DIST)
            {
                m_CharacterAI.ChangeAIState(new IdleAIState());
                if (m_CharacterAI.IsKilled() == false)
                    m_CharacterAI.CanAttackHeart();//Debug.Log ("����Ŀ��");
                m_CharacterAI.Killed();
            }
            return;
        }

        // ��Ŀ���ƶ�
        //Debug.Log ("MoveAIState.��Ŀ���ƶ�");
        m_bOnMove = true;
        m_CharacterAI.MoveTo(m_AttackPosition);
    }
}
