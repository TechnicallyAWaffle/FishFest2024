using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMutations
{
    public Sprite BodySprite { get; }

    public Sprite MouthSprite { get; }

    void MutationPassive();
    void MutationActive();
}
