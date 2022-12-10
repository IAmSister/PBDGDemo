using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʵ��������Ϸ����ֵ
public class AttrFactory : IAttrFactory
{
    private Dictionary<int, BaseAttr> m_SoldierAttrDB = null;
    private Dictionary<int, EnemyBaseAttr> m_EnemyAttrDB = null;
    private Dictionary<int, WeaponAttr> m_WeaponAttrDB = null;
    private Dictionary<int, AdditionalAttr> m_AdditionalAttrDB = null;

    public AttrFactory()
    {
        InitSoldierAttr();
        InitEnemyAttr();
        InitWeaponAttr();
        InitAdditionalAttr();
    }

    // ��������Soldier�Ĕ�ֵ
    private void InitSoldierAttr()
    {
        m_SoldierAttrDB = new Dictionary<int, BaseAttr>();
        // ������ֵ								// ������,�Ƅ��ٶ�,��ֵ���Q
        m_SoldierAttrDB.Add(1, new CharacterBaseAttr(10, 3.0f, "�±�"));
        m_SoldierAttrDB.Add(2, new CharacterBaseAttr(20, 3.2f, "��ʿ"));
        m_SoldierAttrDB.Add(3, new CharacterBaseAttr(30, 3.4f, "��ξ"));
    }

    // ��������Enemy�Ĕ�ֵ
    private void InitEnemyAttr()
    {
        m_EnemyAttrDB = new Dictionary<int, EnemyBaseAttr>();
        // ������,�Ƅ��ٶ�,��ֵ���Q,������,
        m_EnemyAttrDB.Add(1, new EnemyBaseAttr(5, 3.0f, "���`", 10));
        m_EnemyAttrDB.Add(2, new EnemyBaseAttr(15, 3.1f, "ɽ��", 20));
        m_EnemyAttrDB.Add(3, new EnemyBaseAttr(20, 3.3f, "����", 40));
    }

    // ��������Weapon�Ĕ�ֵ
    private void InitWeaponAttr()
    {
        m_WeaponAttrDB = new Dictionary<int, WeaponAttr>();
        // ������,���x,��ֵ���Q
        m_WeaponAttrDB.Add(1, new WeaponAttr(2, 4, "�̘�"));
        m_WeaponAttrDB.Add(2, new WeaponAttr(4, 7, "�L��"));
        m_WeaponAttrDB.Add(3, new WeaponAttr(8, 10, "���Ͳ"));
    }

    // �����ӳ��õĔ�ֵ
    private void InitAdditionalAttr()
    {
        m_AdditionalAttrDB = new Dictionary<int, AdditionalAttr>();

        // ���׮a���r�S�C�a��
        m_AdditionalAttrDB.Add(11, new AdditionalAttr(3, 0, "��ʿ"));
        m_AdditionalAttrDB.Add(12, new AdditionalAttr(5, 0, "�͌�"));
        m_AdditionalAttrDB.Add(13, new AdditionalAttr(10, 0, "Ӣ��"));

        // ��β���������
        m_AdditionalAttrDB.Add(21, new AdditionalAttr(5, 1, "��"));
        m_AdditionalAttrDB.Add(22, new AdditionalAttr(5, 1, "��"));
        m_AdditionalAttrDB.Add(23, new AdditionalAttr(5, 1, "��"));
    }


    // ȡ��Soldier�Ĕ�ֵ
    public override SoldierAttr GetSoldierAttr(int AttrID)
    {
        if (m_SoldierAttrDB.ContainsKey(AttrID) == false)
        {
            Debug.LogWarning("GetSoldierAttr:AttrID[" + AttrID + "]��ֵ������");
            return null;
        }

        // �a��������K�O�����õĔ�ֵ�Y��
        SoldierAttr NewAttr = new SoldierAttr();
        NewAttr.SetSoldierAttr(m_SoldierAttrDB[AttrID]);
        return NewAttr;
    }

    // ȡ�üӳ��^��Soldier��ɫ��ֵ
    public override SoldierAttr GetEliteSoldierAttr(ENUM_AttrDecorator emType, int AttrID, SoldierAttr theSoldierAttr)
    {
        // ȡ�üӳ�Ч���Ĕ�ֵ
        AdditionalAttr theAdditionalAttr = GetAdditionalAttr(AttrID);
        if (theAdditionalAttr == null)
        {
            Debug.LogWarning("GetEliteSoldierAttr:�ӳ˔�ֵ[" + AttrID + "]������");
            return theSoldierAttr;
        }

        // �a���b���
        BaseAttrDecorator theAttrDecorator = null;
        switch (emType)
        {
            case ENUM_AttrDecorator.Prefix:
                theAttrDecorator = new PrefixBaseAttr();
                break;
            case ENUM_AttrDecorator.Suffix:
                theAttrDecorator = new SuffixBaseAttr();
                break;
        }
        if (theAttrDecorator == null)
        {
            Debug.LogWarning("GetEliteSoldierAttr:�o��ᘌ�[" + emType + "]�a���b���");
            return theSoldierAttr;
        }

        // �O���b��񼰼ӳ˔�ֵ
        theAttrDecorator.SetComponent(theSoldierAttr.GetBaseAttr());
        theAttrDecorator.SetAdditionalAttr(theAdditionalAttr);

        // �O���µĔ�ֵ��؂�
        theSoldierAttr.SetBaseAttr(theAttrDecorator);
        return theSoldierAttr;// �؂�
    }

    // ȡ��Enemy�Ĕ�ֵ,�����ⲿ����CritRate
    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        if (m_EnemyAttrDB.ContainsKey(AttrID) == false)
        {
            Debug.LogWarning("GetEnemyAttr:AttrID[" + AttrID + "]��ֵ������");
            return null;
        }

        // �a��������K�O�����õĔ�ֵ�Y��
        EnemyAttr NewAttr = new EnemyAttr();
        NewAttr.SetEnemyAttr(m_EnemyAttrDB[AttrID]);
        return NewAttr;
    }

    // ȡ�������Ĕ�ֵ
    public override WeaponAttr GetWeaponAttr(int AttrID)
    {
        if (m_WeaponAttrDB.ContainsKey(AttrID) == false)
        {
            Debug.LogWarning("GetWeaponAttr:AttrID[" + AttrID + "]��ֵ������");
            return null;
        }
        // ֱ�ӻ؂����õ�������ֵ
        return m_WeaponAttrDB[AttrID];
    }

    // ȡ�üӳ��õĔ�ֵ
    public override AdditionalAttr GetAdditionalAttr(int AttrID)
    {
        if (m_AdditionalAttrDB.ContainsKey(AttrID) == false)
        {
            Debug.LogWarning("GetAdditionalAttr:AttrID[" + AttrID + "]��ֵ������");
            return null;
        }

        // ֱ�ӻ؂��ӳ��õĔ�ֵ
        return m_AdditionalAttrDB[AttrID];
    }
}
