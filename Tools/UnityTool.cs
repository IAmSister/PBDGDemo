using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool
{
    //����GameObject
    public static void Attach(GameObject ParentObj, GameObject ChildObj, Vector3 Pos)
    {
        ChildObj.transform.parent = ParentObj.transform;
        ChildObj.transform.localPosition = Pos;
    }

    //����GameObject
    public static void AttachToRefPos(GameObject ParentObj, GameObject ChildObj, string RefPointName, Vector3 Pos)
    {
        bool bFinded = false;
        Transform[] allChildren = ParentObj.transform.GetComponentsInChildren<Transform>();
        Transform RefTransform = null;
        foreach (Transform child in allChildren)
        {
            if (child.name == RefPointName)
            {
                if (bFinded)
                {
                    Debug.LogWarning("���[" + ParentObj.transform.name + "]�����������ϵĲο���[" + RefPointName + "]");
                    continue;
                }
                bFinded = true;
                RefTransform = child;
            }
        }

        //�Ƿ��ҵ�
        if (bFinded == false)
        {
            Debug.LogWarning("���[" + ParentObj.transform.name + "]�ț]�вο���[" + RefPointName + "]");
            Attach(ParentObj, ChildObj, Pos);
            return;
        }

        ChildObj.transform.parent = RefTransform;
        ChildObj.transform.localPosition = Pos;
        ChildObj.transform.localScale = Vector3.one;
        ChildObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    //�ҵ������ϵ�����
    public static GameObject FindGameObject(string GameObjectName)
    {
        //�ҳ���Ӧ��GameObject
        GameObject pTempGameObj = GameObject.Find(GameObjectName);
        if (pTempGameObj == null)
        {
            Debug.LogWarning("�������Ҳ���GameObject[" + GameObjectName + "]���");
            return null;
        }
        return pTempGameObj;
    }

    //ȡ��������
    public static GameObject FindChildGameObject(GameObject Container, string gameobjectName)
    {
        if (Container == null)
        {
            Debug.LogError("NGUICustomTools.GetChild : Container =null");
            return null;
        }

        Transform pGameObjectTF = null;


        // �ǲ���Container����
        if (Container.name == gameobjectName)
            pGameObjectTF = Container.transform;
        else
        {
            // �ҳ�������Ԫ��						
            Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.name == gameobjectName)
                {
                    if (pGameObjectTF == null)
                        pGameObjectTF = child;
                    else
                        Debug.LogWarning("Container[" + Container.name + "]���ҳ��ظ���Ԫ������[" + gameobjectName + "]");
                }
            }
        }

        // ���]���ҵ�
        if (pGameObjectTF == null)
        {
            Debug.LogError("Ԫ��[" + Container.name + "]�Ҳ�����Ԫ��[" + gameobjectName + "]");
            return null;
        }

        return pGameObjectTF.gameObject;
    }
}
