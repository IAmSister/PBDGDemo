using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun : IWeapon
{
    public WeaponGun()
    {
        m_emWeaponType = ENUM_Weapon.Gun;
    }

    // ��ʾ�����ӵ���Ч
    protected override void DoShowBulletEffect(ICharacter theTarget)
{
    ShowBulletEffect(theTarget.GetPosition(), 0.03f, 0.2f);
}

// ��ʾ��Ч
protected override void DoShowSoundEffect()
{
    ShowSoundEffect("GunShot");
}
}
