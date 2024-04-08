using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMutations
{
    public Sprite Sprite { get; protected set; }
    void MutationPassive();
    void MutationActive();
}
