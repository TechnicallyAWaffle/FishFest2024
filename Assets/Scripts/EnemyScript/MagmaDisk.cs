using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaDisk : EnemyScript
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.Instance.movementSystem.maxSpeed -= 20f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player.Instance.movementSystem.maxSpeed += 20f;
    }

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
