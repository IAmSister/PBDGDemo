using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAssetFactory : IAssetFactory
{
    // �a��Soldier
    public override GameObject LoadSoldier(string AssetName)
    {
        // �d����ڱ����b�õ�Assetʾ��
        //string FilePath = "D:/xxx/Characters/Soldier/"+AssetName+".assetbundle";
        // �����d��
        return null;
    }

    // �a��Enemy
    public override GameObject LoadEnemy(string AssetName)
    {
        // �d����ڱ����b���ϵ�Assetʾ��
        //string RemotePath = "D:/xxx/Characters/Enemy/"+AssetName+".assetbundle";
        // �����d��
        return null;
    }

    // �a��Weapon
    public override GameObject LoadWeapon(string AssetName)
    {
        // �d����ڱ����b���ϵ�Assetʾ��
        //string RemotePath = "D:/xxx/Weapons/"+AssetName+".assetbundle";
        // �����d��
        return null;
    }

    // �a����Ч
    public override GameObject LoadEffect(string AssetName)
    {
        // �d����ڱ����b���ϵ�Assetʾ��
        //string RemotePath = "D:/xxx/Effects/"+AssetName+".assetbundle";
        // �����d��
        return null;
    }

    // �a��AudioClip
    public override AudioClip LoadAudioClip(string ClipName)
    {
        // �d����ڱ����b���ϵ�Assetʾ��
        //string RemotePath = "D:/xxx/Audios/"+AssetName+".assetbundle";
        // �����d��
        return null;
    }

    // �a��Sprite
    public override Sprite LoadSprite(string SpriteName)
    {
        // �d����ڱ����b���ϵ�Assetʾ��
        //string RemotePath = "D:/xxx/Sprites/"+SpriteName+".assetbundle";
        // �����d��
        return null;
    }
}
