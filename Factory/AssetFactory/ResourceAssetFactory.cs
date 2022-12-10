using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Resource��,��Unity Assetʵ������GameObject�Ĺ������
public class ResourceAssetFactory : IAssetFactory
{
    public const string SoldierPath = "Characters/Soldier/";
    public const string EnemyPath = "Characters/Enemy/";
    public const string WeaponPath = "Weapons/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";

    //����Soldier
    public override GameObject LoadSoldier(string AssetName)
    {
        return InstantiateGameObject(SoldierPath + AssetName);
    }

    //����Enemy
    public override GameObject LoadEnemy(string AssetName)
    {
        return InstantiateGameObject(EnemyPath + AssetName);
    }

    // ����Weapon
    public override GameObject LoadWeapon(string AssetName)
    {
        return InstantiateGameObject(WeaponPath + AssetName);
    }

    // ������Ч
    public override GameObject LoadEffect(string AssetName)
    {
        return InstantiateGameObject(EffectPath + AssetName);
    }

    // ����AudioClip
    public override AudioClip LoadAudioClip(string ClipName)
    {
        UnityEngine.Object res = LoadGameObjectFromResourcePath(AudioPath + ClipName);
        if (res == null)
            return null;
        return res as AudioClip;
    }

    // ����Sprite
    public override Sprite LoadSprite(string SpriteName)
    {
        return Resources.Load(SpritePath + SpriteName, typeof(Sprite)) as Sprite;
    }

    // ����GameObject
    private GameObject InstantiateGameObject(string AssetName)
    {
        // ��Resrouce������
        UnityEngine.Object res = LoadGameObjectFromResourcePath(AssetName);
        if (res == null)
            return null;
        return UnityEngine.Object.Instantiate(res) as GameObject;
    }

    // ��Resrouce������
    public UnityEngine.Object LoadGameObjectFromResourcePath(string AssetPath)
    {
        UnityEngine.Object res = Resources.Load(AssetPath);
        if (res == null)
        {
            Debug.LogWarning("�o���d��·��[" + AssetPath + "]�ϵ�Asset");
            return null;
        }
        return res;
    }
}
