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

//武器界面
public abstract class IWeapon
{
    public ENUM_Weapon m_emWeaponType = ENUM_Weapon.Null;

    //数值
    protected int m_AtkPlusValue = 0;//额外增加的攻击力
    protected WeaponAttr m_WeaponAttr = null;//武器的能力

    protected GameObject m_GameObject = null;//显示的Unity模型
    protected ICharacter m_WeaponOwner = null;//武器的拥有者

    //发射特效
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

    //设置显示的Unity模型
    public void SetGameObject(GameObject gameObject)
    {
        this.m_GameObject = gameObject;

        //设定特效元件
        SetupEffect();
    }

    //取得显示的Unity模型
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    //设定武器拥有者
    public void SetOwner(ICharacter owner)
    {
        m_WeaponOwner = owner;
    }

    //设定攻击能力
    public void SetWeaponAttr(WeaponAttr weaponAttr)
    {
        m_WeaponAttr = weaponAttr;
    }

    //设定额外攻击力
    public void SetAtkPlusValue(int value)
    {
        m_AtkPlusValue = value;
    }

    //取得攻击力
    public int GetAtkValue()
    {
        return m_AtkPlusValue + m_WeaponAttr.Atk;
    }

    //取得攻击距离
    public float GetAtkRange()
    {
        return m_WeaponAttr.AtkRange;
    }

    //释放
    public void Release()
    {
        if(m_GameObject != null)
        {
            GameObject.Destroy(m_GameObject);
        }
    }

    //更新
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

    //设定特效元件
    private void SetupEffect()
    {
        GameObject EffectObj = UnityTool.FindChildGameObject(m_GameObject, "Effect");

        //取得特效使用的元件
        m_Line = EffectObj.GetComponent<LineRenderer>();
        m_Particles = EffectObj.GetComponent<ParticleSystem>();
        m_Audio = EffectObj.GetComponent<AudioSource>();
        m_Light = EffectObj.GetComponent<Light>();
    }

    //显示子弹特效
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

    //显示枪口特效
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
        //取得音效

    }

    //攻击目标
    public void Fire(ICharacter theTarget)
    {
        //显示武器发射/枪口特效
        ShowShootEffect();

        //显示武器子弹特效(子类别实作)
        DoShowBulletEffect(theTarget);

        //显示音效(子类别实作)
        DoShowSoundEffect();

        //直接命中攻击
        theTarget.UnderAttack(m_WeaponOwner);
    }

    //显示武器子弹特效
    protected abstract void DoShowBulletEffect(ICharacter theTarget);
    //显示音效
    protected abstract void DoShowSoundEffect();
}
