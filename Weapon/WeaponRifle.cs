using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRifle : IWeapon
{
    public WeaponRifle()
    {
        m_emWeaponType = ENUM_Weapon.Rifle;
    }

    // ��ʾ�����ӵ���Ч
    protected override void DoShowBulletEffect(ICharacter theTarget)
    {
        ShowBulletEffect(theTarget.GetPosition(), 0.5f, 0.2f);
    }

    // ��ʾ��Ч
    protected override void DoShowSoundEffect()
    {
        ShowSoundEffect("RifleShot");
    }
}
