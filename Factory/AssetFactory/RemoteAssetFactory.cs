using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteAssetFactory : IAssetFactory
{
    // 產生Soldier
    public override GameObject LoadSoldier(string AssetName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Characters/Soldier/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0); 
        return null;
    }

    // 產生Enemy
    public override GameObject LoadEnemy(string AssetName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Characters/Enemy/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // 產生Weapon
    public override GameObject LoadWeapon(string AssetName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Weapons/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // 產生特效
    public override GameObject LoadEffect(string AssetName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Effects/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // 產生AudioClip
    public override AudioClip LoadAudioClip(string ClipName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Audios/"+ClipName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // 產生Sprite
    public override Sprite LoadSprite(string SpriteName)
    {
        // 載入放在網路上的Asset示意
        //string RemotePath = "http://127.0.0.1/PBDResource/Sprites/"+SpriteName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }


}
