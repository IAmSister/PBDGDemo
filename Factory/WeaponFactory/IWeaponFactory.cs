using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//产生武器工厂界面
public abstract class IWeaponFactory
{
    // 建立武器
    public abstract IWeapon CreateWeapon(ENUM_Weapon emWeapon);
}
