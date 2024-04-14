using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MagmaDisk : EnemyScript
{
    Queue<MovementMod> moveDebuffs = new();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MovementMod magmaDebuff = new MovementMod("MagmaDebuff", -20f);
            moveDebuffs.Enqueue(magmaDebuff);
            Player.Instance.movementSystem.AddSwimMod(magmaDebuff);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player.Instance.movementSystem.RemoveSwimMod(moveDebuffs.Dequeue());
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
