using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ɫ��ֵ�������
public abstract class IAttrStrategy
{
    //��ʼ����ֵ
    public abstract void InitAttr(ICharacterAttr characterAttr);

    //�����ӳ�
    public abstract int GetAtkPlusValue(ICharacterAttr characterAttr);

    //ȡ�ü��˺�ֵ
    public abstract int GetDmgDescValue(ICharacterAttr characterAttr);
}
