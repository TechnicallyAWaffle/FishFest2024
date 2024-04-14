using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMutation : MutationBase
{
    [SerializeField] float swimSpeedBonus = 7.5f;

    [SerializeField] float dashSpeedBonus = 5f;

    MovementMod swimBuff;
    MovementMod dashBuff;

    public override void MutationActive() { }

    public override void MutationPassive() { }

    public override void OnMutationBegin()
    {
        // TODO: Apply movespeed & dash buff
        player.movementSystem.AddSwimMod(swimBuff = new MovementMod("ButterflyBuff", swimSpeedBonus));
        player.movementSystem.AddDashMod(dashBuff = new MovementMod("ButterflyBuff", dashSpeedBonus));
    }

    public override void OnMutationEnd()
    {
        // TODO: Unapply movespeed & dash buff
        player.movementSystem.RemoveSwimMod(swimBuff);
        player.movementSystem.RemoveDashMod(dashBuff);
    }
}
