using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter
{
    protected string m_Name = ""; //����
    protected GameObject m_GameObject = null;//��ʾ��Unityģ��
    protected UnityEngine.AI.NavMeshAgent m_NavAgent = null;//���ƽ�ɫ�ƶ�ʹ��
    protected AudioSource m_Audio = null;

    protected string m_IconSpriteName = ""; // ��ʾIcon
    protected string m_AssetName = "";      // ģ������
    protected int m_AttrID = 0;         // ʹ�õĽ�ɫ���Ա��

    protected bool m_bKilled = false;           // �Ƿ�����
    protected bool m_bCheckKilled = false;      // �Ƿ�ȷ�Ϲ������¼�
    protected float m_RemoveTimer = 1.5f;       // ���������Ƴ�
    protected bool m_bCanRemove = false;		// �Ƿ�����Ƴ�

    private IWeapon m_Weapon = null;//ʹ�õ�����
    protected ICharacterAttr m_Attribute = null;//��ֵ
    protected ICharacterAI m_AI = null;//AI

    //���캯��
    public ICharacter()
    {

    }

    public void SetGameObject(GameObject theGameObject)
    {
        m_GameObject = theGameObject;
        m_NavAgent = m_GameObject.GetComponent<NavMeshAgent>();
        m_Audio = m_GameObject.GetComponent<AudioSource>();
    }
    // ȡ��Unityģ��
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }
    //�ͷ�
    public void Release()
    {
        if(m_GameObject != null)
        {
            GameObject.Destroy(m_GameObject);
        }
    }

    //����
    public string GetName()
    {
        return m_Name;
    }

    //ȡ��Asset����
    public string GetAssetName()
    {
        return m_AssetName;
    }

    //��ȡIcon����
    public string GetIconSpriteName()
    {
        return m_IconSpriteName;
    }

    // ȡ������ID
    public int GetAttrID()
    {
        return m_AttrID;
    }

    // ȡ��Ŀǰ��ֵ
    public ICharacterAttr GetCharacterAttr()
    {
        return m_Attribute;
    }

    // ȡ�ý�ɫ����
    public string GetCharacterName()
    {
        return m_Name;
    }

    public void Update()
    {
        if (m_bKilled)
        {
            m_RemoveTimer -= Time.deltaTime;
            if (m_RemoveTimer <= 0)
                m_bCanRemove = true;
        }

        m_Weapon.Update();
    }

    #region �ƄӼ�λ��	
    // �Ƅӵ�Ŀ��
    public void MoveTo(Vector3 Position)
    {
        m_NavAgent.SetDestination(Position);
    }

    // ֹͣ�ƶ�
    public void StopMove()
    {
        m_NavAgent.isStopped = true;
    }

    //  ȡ��λ��
    public Vector3 GetPosition()
    {
        return m_GameObject.transform.position;
    }
    #endregion

    #region AI
    // �趨           AI
    public void SetAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;
    }

    // ����AI
    public void UpdateAI(List<ICharacter> Targets)
    {
        m_AI.Update(Targets);
    }

    // ֪ͨAI�н�ɫ���Ƴ�
    public void RemoveAITarget(ICharacter Targets)
    {
        m_AI.RemoveAITarget(Targets);
    }
    #endregion

    #region ����
    //����Ŀ��
    public void Attack(ICharacter Target)
    {
        // �趨�������⹥���ӳ�
        SetWeaponAtkPlusValue(m_Attribute.GetAtkPlusValue());

        // ����
        WeaponAttackTarget(Target);

        // ��������
        m_GameObject.GetComponent<CharacterMovement>().PlayAttackAnim();

        // ����Ŀ��
        m_GameObject.transform.forward = Target.GetPosition() - GetPosition();
    }

    // ��������ɫ����
    public abstract void UnderAttack(ICharacter Attacker);
    #endregion

    #region ����
    // �趨ʹ�õ�����
    public void SetWeapon(IWeapon Weapon)
    {
        if (m_Weapon != null)
            m_Weapon.Release();
        m_Weapon = Weapon;

        // �趨����ӵ����
        m_Weapon.SetOwner(this);

        // �趨Unity GameObject�Ĳ㼶
        UnityTool.AttachToRefPos(m_GameObject, m_Weapon.GetGameObject(), "weapon-point", Vector3.zero);
    }

    // ȡ������
    public IWeapon GetWeapon()
    {
        return m_Weapon;
    }

    // �趨���⹥����
    protected void SetWeaponAtkPlusValue(int Value)
    {
        m_Weapon.SetAtkPlusValue(Value);
    }

    // ��������Ŀ��
    protected void WeaponAttackTarget(ICharacter Target)
    {
        m_Weapon.Fire(Target);
    }

    // ���㹥���� 
    public int GetAtkValue()
    {
        // ���������� + ��ɫ��ֵ�ļӳ�
        return m_Weapon.GetAtkValue();
    }

    // ȡ�ù�������
    public float GetAttackRange()
    {
        return m_Weapon.GetAtkRange();
    }
    #endregion

    #region �������Ƴ�
    // ����
    public void Killed()
    {
        if (m_bKilled == true)
            return;
        m_bKilled = true;
        m_bCheckKilled = false;
    }

    // �Ƿ�����
    public bool IsKilled()
    {
        return m_bKilled;
    }

    // �Ƿ�ȷ��������
    public bool CheckKilledEvent()
    {
        if (m_bCheckKilled)
            return true;
        m_bCheckKilled = true;
        return false;
    }

    //  �Ƿ�����Ƴ�
    public bool CanRemove()
    {
        return m_bCanRemove;
    }
    #endregion

    #region ��ɫ��ֵ
    // �趨��ɫ��ֵ
    public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
    {
        // �趨
        m_Attribute = CharacterAttr;
        m_Attribute.InitAttr();

        // �趨�ƶ��ٶ�
        m_NavAgent.speed = m_Attribute.GetMoveSpeed();

        // ����
        m_Name = m_Attribute.GetAttrName();
    }
    #endregion

    #region ��Ч��Ч

    // ������Ч
    public void PlaySound(string ClipName)
    {
        //  ȡ����Ч
        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        AudioClip theClip = Factory.LoadAudioClip(ClipName);
        if (theClip == null)
            return;
        m_Audio.clip = theClip;
        m_Audio.Play();
    }

    // ������Ч
    public void PlayEffect(string EffectName)
    {
        //  ȡ����Ч
        IAssetFactory Factory = PBDFactory.GetAssetFactory();
        GameObject EffectObj = Factory.LoadEffect(EffectName);
        if (EffectObj == null)
            return;

        // ����
        UnityTool.Attach(m_GameObject, EffectObj, Vector3.zero);
    }
    #endregion

    // ִ��Visitor
    public virtual void RunVisitor(ICharacterVisitor Visitor)
    {
        Visitor.VisitCharacter(this);
    }
}
