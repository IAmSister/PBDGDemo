using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageHandler : NormalStageHandler
{
    public BossStageHandler(IStageScore StateScore, IStageData StageData) : base(StateScore, StageData)
    { }

    // “pÊ§µÄÉúÃüÖµ
    public override int LoseHeart()
    {
        return StageSystem.MAX_HEART;
    }
}
