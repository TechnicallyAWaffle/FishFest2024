using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : EnemyScript
{
    private float currentTime = 5;
    private float targetTime = 5;

    public override void ChasingBehaviour()
    {
        base.ChasingBehaviour();
    }

    public override void FleeingBehaviour()
    {
        base.FleeingBehaviour();
    }

    public override void NeutralBehaviour()
    {
        base.NeutralBehaviour();
    }

    public override void PheromoneBehaviour()
    {
        base.PheromoneBehaviour();
    }

}
