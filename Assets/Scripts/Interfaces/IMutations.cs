using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMutations
{
    public Sprite BodySprite { get; }

    public Sprite MouthSprite { get; }

    void SetPlayer(Player player);
    void OnMutationBegin();
    void MutationPassive();
    void MutationActive();
    void OnMutationEnd();
}
