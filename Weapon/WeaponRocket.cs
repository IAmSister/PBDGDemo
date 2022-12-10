using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRocket : IWeapon
{
    public WeaponRocket()
    {
        m_emWeaponType = ENUM_Weapon.Rocket;
    }

    // ��ʾ�����ӵ���Ч
    protected override void DoShowBulletEffect(ICharacter theTarget)
    {
        ShowBulletEffect(theTarget.GetPosition(), 0.8f, 0.5f);
    }

    // ��ʾ��Ч
    protected override void DoShowSoundEffect()
    {
        ShowSoundEffect("RocketShot");
    }
}
