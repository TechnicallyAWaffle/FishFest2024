using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reeflow : EnemyScript
{
    private enum BehaviourState
    { 
        CHASING,
        FLEEING,
        NEUTRAL
    }

    BehaviourState currentState;

    private void CheckState(BehaviourState state)
    {
        if (currentState == state)
        {
            if (speed < 100)
                speed += 1f;
        }
        else
            speed = defaultSpeed;
    }

    public override void ChasingBehaviour()
    {
        CheckState(BehaviourState.CHASING);
        currentState = BehaviourState.CHASING;
        base.ChasingBehaviour();
    }

    public override void FleeingBehaviour()
    {
        CheckState(BehaviourState.FLEEING);
        currentState = BehaviourState.CHASING;
        base.FleeingBehaviour();
    }

    public override void NeutralBehaviour()
    {
        CheckState(BehaviourState.NEUTRAL);
        currentState = BehaviourState.NEUTRAL;
        base.NeutralBehaviour();
    }

    public override void PheromoneBehaviour()
    {
        base.PheromoneBehaviour();
    }

}
