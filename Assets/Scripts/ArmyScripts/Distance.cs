using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : BaseSoldat
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void ChangeState(AIState state)
    {
        // LongFight
        if (state == AIState.LongFight) Debug.Log("LongFight State");
    }
}