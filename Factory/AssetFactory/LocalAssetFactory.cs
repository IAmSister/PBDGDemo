using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAssetFactory : IAssetFactory
{
    // 產生Soldier
    public override GameObject LoadSoldier(string AssetName)
    {
        // 載入放在本地裝置的Asset示意
        //string FilePath = "D:/xxx/Characters/Soldier/"+AssetName+".assetbundle";
        // 執行載入
        return null;
    }

    // 產生Enemy
    public override GameObject LoadEnemy(string AssetName)
    {
        // 載入放在本地裝置上的Asset示意
        //string RemotePath = "D:/xxx/Characters/Enemy/"+AssetName+".assetbundle";
        // 執行載入
        return null;
    }

    // 產生Weapon
    public override GameObject LoadWeapon(string AssetName)
    {
        // 載入放在本地裝置上的Asset示意
        //string RemotePath = "D:/xxx/Weapons/"+AssetName+".assetbundle";
        // 執行載入
        return null;
    }

    // 產生特效
    public override GameObject LoadEffect(string AssetName)
    {
        // 載入放在本地裝置上的Asset示意
        //string RemotePath = "D:/xxx/Effects/"+AssetName+".assetbundle";
        // 執行載入
        return null;
    }

    // 產生AudioClip
    public override AudioClip LoadAudioClip(string ClipName)
    {
        // 載入放在本地裝置上的Asset示意
        //string RemotePath = "D:/xxx/Audios/"+AssetName+".assetbundle";
        // 執行載入
        return null;
    }

    // 產生Sprite
    public override Sprite LoadSprite(string SpriteName)
    {
        // 載入放在本地裝置上的Asset示意
        //string RemotePath = "D:/xxx/Sprites/"+SpriteName+".assetbundle";
        // 執行載入
        return null;
    }
}
