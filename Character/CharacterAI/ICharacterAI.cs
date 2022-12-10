using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ɫ��AI
public abstract class ICharacterAI
{
    protected ICharacter m_Character = null;
    protected float m_AttackRange = 2;
    protected IAIState m_AIState = null;

    protected const float ATTACK_COOLD_DOWN = 1f;//������CoolDown
    protected float m_CoolDown = ATTACK_COOLD_DOWN;

    public ICharacterAI(ICharacter character)
    {
        m_Character = character;
        m_AttackRange = character.GetAttackRange();
    }

    //����AI״̬
    public virtual void ChangeAIState(IAIState NewAIState)
    {
        m_AIState = NewAIState;
        m_AIState.SetCharacterAI(this);
    }

    //����Ŀ��
    public virtual void Attack(ICharacter Target)
    {
        // ʱ�䵽�˲Ź���
        m_CoolDown -= Time.deltaTime;
        if (m_CoolDown > 0)
            return;
        m_CoolDown = ATTACK_COOLD_DOWN;
        m_Character.Attack(Target);
    }

    //�Ƿ��ڹ���������
    public bool TargetInAttackRange(ICharacter Target)
    {
        float dist = Vector3.Distance(m_Character.GetPosition(),
                                       Target.GetPosition());
        return (dist <= m_AttackRange);
    }

    //Ŀ���λ��
    public Vector3 GetPosition()
    {
        return m_Character.GetGameObject().transform.position;
    }

    //�ƶ�
    public void MoveTo(Vector3 Position)
    {
        m_Character.MoveTo(Position);
    }

    //ֹͣ�ƶ�
    public void StopMove()
    {
        m_Character.StopMove();
    }

    //�趨����
    public void Killed()
    {
        m_Character.Killed();
    }

    //�Ƿ�����
    public bool IsKilled()
    {
        return m_Character.IsKilled();
    }

    //Ŀ���Ƴ�
    public void RemoveAITarget(ICharacter Target)
    {
        m_AIState.RemoveTarget(Target);
    }

    //����AI
    public void Update(List<ICharacter> Targets)
    {
        m_AIState.Update(Targets);
    }

    //�Ƿ���Թ���Heart
    public abstract bool CanAttackHeart();
}
