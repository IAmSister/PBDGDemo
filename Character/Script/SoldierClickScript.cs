using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ɫ�Ƿ񱻵㵽
public class SoldierOnClick : MonoBehaviour
{
    public ISoldier Solder = null;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        //Debug.Log ("CharacterOnClick.OnClick:" + gameObject.name);
        PBaseDefenseGame.Instance.ShowSoldierInfo(Solder);
    }
}
