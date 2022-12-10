using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�з���ɫAI
public class EnemyAI : ICharacterAI
{
    private static StageSystem m_StageSystem = null;
    private Vector3 m_AttackPosition = Vector3.zero;

    // ֱ�ӌ��ؿ�ϵͳֱ��ע���EnemyAI���ʹ��
    public static void SetStageSystem(StageSystem StageSystem)
    {
        m_StageSystem = StageSystem;
    }
    public EnemyAI(ICharacter character ,Vector3 AttackPosition) : base(character)
    {
        m_AttackPosition = AttackPosition;

        //һ��ʼ��ʼ��״̬
        ChangeAIState(new IdleAIState());
    }


    //����AI״̬
    public override void ChangeAIState(IAIState NewAIState)
    {
        base.ChangeAIState(NewAIState);
        //Enemy��AIҪ�趨������Ŀ��
        NewAIState.SetAttackPosition(m_AttackPosition);
    }

    //�Ƿ���Թ���Heart
    public override bool CanAttackHeart()
    {
        //֪ͨȥ��һ����
        m_StageSystem.LoseHeart();
        return true;
    }
}
