using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteAssetFactory : IAssetFactory
{
    // �a��Soldier
    public override GameObject LoadSoldier(string AssetName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Characters/Soldier/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0); 
        return null;
    }

    // �a��Enemy
    public override GameObject LoadEnemy(string AssetName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Characters/Enemy/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // �a��Weapon
    public override GameObject LoadWeapon(string AssetName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Weapons/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // �a����Ч
    public override GameObject LoadEffect(string AssetName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Effects/"+AssetName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // �a��AudioClip
    public override AudioClip LoadAudioClip(string ClipName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Audios/"+ClipName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }

    // �a��Sprite
    public override Sprite LoadSprite(string SpriteName)
    {
        // �d����ھW·�ϵ�Assetʾ��
        //string RemotePath = "http://127.0.0.1/PBDResource/Sprites/"+SpriteName+".assetbundle";
        //WWW.LoadFromCacheOrDownload( RemotePath,0);
        return null;
    }


}
