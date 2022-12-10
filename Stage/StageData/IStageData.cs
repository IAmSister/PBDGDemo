using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//关卡资讯界面
public abstract class IStageData 
{
    public abstract void Update();
    public abstract bool IsFinished();
    public abstract void Reset();
}
