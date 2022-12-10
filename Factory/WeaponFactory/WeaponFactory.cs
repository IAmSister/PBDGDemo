using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������
public class WeaponFactory : IWeaponFactory
{
    public WeaponFactory()
    {
    }

    // ��������
    public override IWeapon CreateWeapon(ENUM_Weapon emWeapon)
    {
        IWeapon pWeapon = null;
        string AssetName = "";  // Unityģ������
        int AttrID = 0;     // ����������ֵ

        // ������
        switch (emWeapon)
        {
            case ENUM_Weapon.Gun:
                pWeapon = new WeaponGun();
                AssetName = "WeaponGun";
                AttrID = 1;
                break;
            case ENUM_Weapon.Rifle:
                pWeapon = new WeaponRifle();
                AssetName = "WeaponRifle";
                AttrID = 2;
                break;
            case ENUM_Weapon.Rocket:
                pWeapon = new WeaponRocket();
                AssetName = "WeaponRocket";
                AttrID = 3;
                break;
            default:
                Debug.LogWarning("CreateWeapon:�o������[" + emWeapon + "]");
                return null;
        }

        // �a��Asset
        IAssetFactory AssetFactory = PBDFactory.GetAssetFactory();
        GameObject WeaponGameObjet = AssetFactory.LoadWeapon(AssetName);
        pWeapon.SetGameObject(WeaponGameObjet);

        // ȡ������������
        IAttrFactory theAttrFactory = PBDFactory.GetAttrFactory();
        WeaponAttr theWeaponAttr = theAttrFactory.GetWeaponAttr(AttrID);

        // �O������������
        pWeapon.SetWeaponAttr(theWeaponAttr);

        return pWeapon;
    }
}
