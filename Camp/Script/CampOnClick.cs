using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//��Ӫ����ɹ���֪ͨ��ʾ
public class CampOnClick : MonoBehaviour
{
    public ICamp theCamp = null;

    // Use this for initialization
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnClick()
    {
        // ��ʾ��ӪѶϢ
        PBaseDefenseGame.Instance.ShowCampInfo(theCamp);
    }
}
