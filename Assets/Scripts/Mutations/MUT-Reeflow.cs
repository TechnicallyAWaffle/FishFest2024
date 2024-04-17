using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Collider2D))]
public class ReeflowMutation : MutationBase
{
    [SerializeField]
    float proximitySwimBuff = 20f;

    MovementMod speedBuff = null;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == null) { return; }    

        if (collision.CompareTag("Enemy") && speedBuff == null)
        {
            trailRenderer.enabled = true;
            speedBuff = new MovementMod("ReeflowBuff", proximitySwimBuff);
            player.movementSystem.AddSwimMod(speedBuff);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player == null) { return; }

        if (collision.CompareTag("Enemy") && speedBuff != null)
        {
            trailRenderer.enabled = false;
            player.movementSystem.RemoveSwimMod(speedBuff);
            speedBuff = null;
        }
    }

    public override void MutationActive()
    {
    }

    public override void MutationPassive()
    {
    }

    public override void OnMutationBegin()
    {
    }

    public override void OnMutationEnd()
    {
    }
}
