using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallopMutation : MutationBase, IMutations
{
    [SerializeField]
    float shootForce;

    public override Sprite BodySprite => bodySprite;
    public override Sprite MouthSprite => mouthSprite;

    public override void MutationActive()
    {
        Player.Instance.PelletShooter.ShootPellet(shootForce);
    }

    public override void MutationPassive() {}
}
