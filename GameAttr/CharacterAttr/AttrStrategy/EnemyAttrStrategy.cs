using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�з���λ����ֵ�������
public class EnemyAttrStrategy : IAttrStrategy
{
    // ��ʼ����ֵ
    public override void InitAttr(ICharacterAttr CharacterAttr)
    {
        // ���ü���
    }

    // �����ӳ�
    public override int GetAtkPlusValue(ICharacterAttr CharacterAttr)
    {
        // �Ƿ�Ϊ�з���ֵ
        EnemyAttr theEnemyAttr = CharacterAttr as EnemyAttr;
        if (theEnemyAttr == null)
            return 0;

        // �������ʻش������ӳ�ֵ
        int RandValue = UnityEngine.Random.Range(0, 100);
        if (theEnemyAttr.GetCritRate() >= RandValue)
        {
            theEnemyAttr.CutdownCritRate();     // ���ٱ�����
            return theEnemyAttr.GetMaxHP() * 5;     // Ѫ����5��ֵ
        }
        return 0;
    }

    // ȡ�ü��˺�ֵ
    public override int GetDmgDescValue(ICharacterAttr CharacterAttr)
    {
        // �]�м���
        return 0;
    }
}
