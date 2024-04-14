using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoralLumpMutation : MutationBase, IMutations
{
    [SerializeField]
    float invincibleTime = 1f;

    [SerializeField]
    float invincibleCooldown = 5f;

    [SerializeField]
    ParticleSystem invincibleVFX;

    bool canActivate = true;

    public override void MutationActive()
    {
        if (canActivate)
        {
            Debug.Log("Hello!");
            canActivate = false;
            Player.Instance.Invincible = true;
            invincibleVFX.Play();
            StartCoroutine(CallbackTimer(invincibleTime, EndInvincibility));
        }
    }

    public override void MutationPassive()
    {

    }

    private void EndInvincibility()
    {
        Player.Instance.Invincible = false;
        StartCoroutine(CallbackTimer(invincibleCooldown, EndCooldown));
    }

    private void EndCooldown()
    {
        canActivate = true;
    }

    IEnumerator CallbackTimer(float time, UnityAction onTimerEnd)
    {
        yield return new WaitForSeconds(time);

        onTimerEnd.Invoke();
    }

    public override void OnMutationBegin() { }

    public override void OnMutationEnd() { }
}
