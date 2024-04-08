using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : EnemyScript
{
    private float currentTime = 5;
    private float targetTime = 5;
    public bool isInvincible = false;

    public override void ChasingBehaviour()
    {
        isInvincible = true;
        base.ChasingBehaviour();
    }

    public override void FleeingBehaviour()
    {
        isInvincible = true;
        base.FleeingBehaviour();
    }

    public override void NeutralBehaviour()
    {
        isInvincible = false;
        base.NeutralBehaviour();
    }

    public override void PheromoneBehaviour()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            isInvincible = false;
        }
        else
        {
            currentTime = targetTime;
            isInvincible = true;
        }
            base.PheromoneBehaviour();
    }

}
