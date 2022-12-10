using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy��ֵ
public class EnemyAttr : ICharacterAttr
{
    protected int m_CritRate = 0;//������
    public EnemyAttr()
    {
        
    }

    //�趨��ɫ��ֵ�������ⲿ������
    public void SetEnemyAttr(EnemyBaseAttr EnemyBaseAttr)
    {
        // ����Ԫ��
        base.SetBaseAttr(EnemyBaseAttr);

        // �ⲿ����
        m_CritRate = EnemyBaseAttr.GetInitCritRate();
    }

    // ������
    public int GetCritRate()
    {
        return m_CritRate;
    }

    // ���ٱ�����
    public void CutdownCritRate()
    {
        m_CritRate -= m_CritRate / 2;
    }
}
