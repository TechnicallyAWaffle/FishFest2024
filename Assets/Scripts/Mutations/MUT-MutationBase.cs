using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MutationBase : MonoBehaviour, IMutations
{
    [SerializeField]
    protected Sprite bodySprite;

    [SerializeField]
    protected Sprite mouthSprite;

    public virtual Sprite BodySprite => bodySprite;
    public virtual Sprite MouthSprite => mouthSprite;

    protected Player player;

    public virtual void SetPlayer(Player player) {  this.player = player; }
    public abstract void OnMutationBegin();
    public abstract void MutationActive();
    public abstract void MutationPassive();
    public abstract void OnMutationEnd();
}
