using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI״̬����
public abstract class IAIState
{
    protected ICharacterAI m_CharacterAI = null;//��ɫAI(״̬��ӵ����)

    public IAIState()
    {

    }

    //�趨CharacterAI�Ķ���
    public void SetCharacterAI(ICharacterAI characterAI)
    {
        m_CharacterAI = characterAI;
    }
    //�趨Ҫ������Ŀ��
    public virtual void SetAttackPosition(Vector3 AttackPosition)
    { 

    }

    // ����
    public abstract void Update(List<ICharacter> Targets);

    // Ŀ�걻�Ƴ�
    public virtual void RemoveTarget(ICharacter Target)
    {

    }
}
