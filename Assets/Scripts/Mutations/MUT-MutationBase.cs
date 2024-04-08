using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MutationBase : MonoBehaviour, IMutations
{
    [SerializeField]
    protected Sprite bodySprite;

    [SerializeField]
    protected Sprite mouthSprite;

    public abstract Sprite BodySprite { get; }
    public abstract Sprite MouthSprite { get; }

    public abstract void MutationActive();
    public abstract void MutationPassive();
}
