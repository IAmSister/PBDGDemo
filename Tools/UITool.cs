using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UITool
{
    private static GameObject m_CanvasObj = null;//�����ϵ�2D�������

    public static void ReleaseCanvas()
    {
        m_CanvasObj = null;
    }

    //��Ѱ�޶���Canvas�����µ�UI����
    public static GameObject FindUIGameObject(string UIName)
    {
        if (m_CanvasObj == null)
        {
            m_CanvasObj = UnityTool.FindGameObject("Canvas");
        }
        if(m_CanvasObj == null) { 
        return null;
        }
        return UnityTool.FindChildGameObject(m_CanvasObj, UIName);
    }

    //ȡ��UI���
    public static T GetUIComponent<T>(GameObject Container, string UIName) where T : UnityEngine.Component
    {
        // �ҳ������ 
        GameObject ChildGameObject = UnityTool.FindChildGameObject(Container, UIName);
        if (ChildGameObject == null)
            return null;

        T tempObj = ChildGameObject.GetComponent<T>();
        if (tempObj == null)
        {
            Debug.LogWarning("Ԫ��[" + UIName + "]����[" + typeof(T) + "]");
            return null;
        }
        return tempObj;
    }

    public static Button GetButton(string BtnName)
    {
        //ȡ��Canvas
        GameObject UIRoot = GameObject.Find("Canvas");
        if(UIRoot == null)
        {
            Debug.LogWarning("�����ϛ]��UI Canvas");
            return null;
        }

        //�ҳ���Ӧ��Button
        Transform[] allChildren = UIRoot.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.name == BtnName)
            {
                Button tmpBtn = child.gameObject.GetComponent<Button>();
                if (tmpBtn == null)
                    Debug.LogWarning("UIԭ��[" + BtnName + "]����Button");
                return tmpBtn;
            }
        }
        Debug.LogWarning("UI Canvas�Л]��Button[" + BtnName + "]����");
        return null;
    }

    // ȡ��UIԪ��
    public static T GetUIComponent<T>(string UIName) where T : UnityEngine.Component
    {
        // ȡ��Canvas
        GameObject UIRoot = GameObject.Find("Canvas");
        if (UIRoot == null)
        {
            Debug.LogWarning("�����ϛ]��UI Canvas");
            return null;
        }
        return GetUIComponent<T>(UIRoot, UIName);
    }
}