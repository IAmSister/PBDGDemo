using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Weapon
{
    Null = 0,
    Gun = 1,
    Rifle = 2,
    Rocket = 3,
    Max
}

//��������
public abstract class IWeapon
{
    public ENUM_Weapon m_emWeaponType = ENUM_Weapon.Null;

    //��ֵ
    protected int m_AtkPlusValue = 0;//�������ӵĹ�����
    protected WeaponAttr m_WeaponAttr = null;//����������

    protected GameObject m_GameObject = null;//��ʾ��Unityģ��
    protected ICharacter m_WeaponOwner = null;//������ӵ����

    //������Ч
    protected float m_EffectDisplayTime = 0;
    protected ParticleSystem m_Particles;
    protected LineRenderer m_Line;
    protected AudioSource m_Audio;
    protected Light m_Light;

    public IWeapon()
    {

    }
    public ENUM_Weapon GetWeaponType()
    {
        return m_emWeaponType;
    }

    //������ʾ��Unityģ��
    public void SetGameObject(GameObject gameObject)
    {
        this.m_GameObject = gameObject;

        //�趨��ЧԪ��
        SetupEffect();
    }

    //ȡ����ʾ��Unityģ��
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    //�趨����ӵ����
    public void SetOwner(ICharacter owner)
    {
        m_WeaponOwner = owner;
    }

    //�趨��������
    public void SetWeaponAttr(WeaponAttr weaponAttr)
    {
        m_WeaponAttr = weaponAttr;
    }

    //�趨���⹥����
    public void SetAtkPlusValue(int value)
    {
        m_AtkPlusValue = value;
    }

    //ȡ�ù�����
    public int GetAtkValue()
    {
        return m_AtkPlusValue + m_WeaponAttr.Atk;
    }

    //ȡ�ù�������
    public float GetAtkRange()
    {
        return m_WeaponAttr.AtkRange;
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
    public void Update()
    {
        if(m_EffectDisplayTime > 0)
        {
            m_EffectDisplayTime -= Time.deltaTime;
            if(m_EffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    private void DisableEffect()
    {
        if (m_Line != null)
            m_Line.enabled = false;
        if (m_Light != null)
            m_Light.enabled = false;
    }

    //�趨��ЧԪ��
    private void SetupEffect()
    {
        GameObject EffectObj = UnityTool.FindChildGameObject(m_GameObject, "Effect");

        //ȡ����Чʹ�õ�Ԫ��
        m_Line = EffectObj.GetComponent<LineRenderer>();
        m_Particles = EffectObj.GetComponent<ParticleSystem>();
        m_Audio = EffectObj.GetComponent<AudioSource>();
        m_Light = EffectObj.GetComponent<Light>();
    }

    //��ʾ�ӵ���Ч
    protected void ShowBulletEffect(Vector3 TargetPosition, float LineWidth, float DisplayTime)
    {
        if(m_Line == null)
        {
            return;
        }
        m_Line.enabled = true;
        m_Line.startWidth = LineWidth;
        m_Line.endWidth = LineWidth;
        m_Line.SetPosition(0, m_GameObject.transform.position);
        m_Line.SetPosition(1, TargetPosition);
        m_EffectDisplayTime = DisplayTime;
    }

    //��ʾǹ����Ч
    protected void ShowShootEffect()
    {
        if(m_Particles != null)
        {
            m_Particles.Stop();
            m_Particles.Play();
        }
        if (m_Light != null)
            m_Line.enabled = true;
    }

    protected void ShowSoundEffect(string ClipMame)
    {
        if(m_Audio == null)
        {
            return;
        }
        //ȡ����Ч

    }

    //����Ŀ��
    public void Fire(ICharacter theTarget)
    {
        //��ʾ��������/ǹ����Ч
        ShowShootEffect();

        //��ʾ�����ӵ���Ч(�����ʵ��)
        DoShowBulletEffect(theTarget);

        //��ʾ��Ч(�����ʵ��)
        DoShowSoundEffect();

        //ֱ�����й���
        theTarget.UnderAttack(m_WeaponOwner);
    }

    //��ʾ�����ӵ���Ч
    protected abstract void DoShowBulletEffect(ICharacter theTarget);
    //��ʾ��Ч
    protected abstract void DoShowSoundEffect();
}
