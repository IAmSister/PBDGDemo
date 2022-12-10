using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Unity Assetʵ�廯��GameObject�Ĺ������
public abstract class IAssetFactory
{
    // ����Soldier
    public abstract GameObject LoadSoldier(string AssetName);

    // ����Enemy
    public abstract GameObject LoadEnemy(string AssetName);

    // ����Weapon
    public abstract GameObject LoadWeapon(string AssetName);

    // ������Ч
    public abstract GameObject LoadEffect(string AssetName);

    // ����AudioClip
    public abstract AudioClip LoadAudioClip(string ClipName);

    // ����Sprite
    public abstract Sprite LoadSprite(string SpriteName);
}
/*
 * ʹ��Abstract Factory Patterny������,
 * ׌GameObject�Įa��������Uniyt Asset���õ�λ�Á��d��Asset
 * �Ȍ�������ResourceĿ��µ�Asset��Remote(Web Server)�ϵ�
 * ��Unity�S���汾�����M��Ҳ�S���ṩ��ͬ���d�뷽ʽ�����N�҂��Ϳ���
 * ���Ȍ�һ��IAssetFactory����e����׃��
 */