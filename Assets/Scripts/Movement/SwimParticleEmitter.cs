using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimParticleEmitter : MonoBehaviour
{
    ParticleSystem swimParticleSystem;

    private void Awake()
    {
        swimParticleSystem = GetComponent<ParticleSystem>();
    }

    public void EmitAwayFromDirection(float degree)
    {
        transform.rotation = Quaternion.Euler(degree, -90, 0);

        swimParticleSystem.Play();
    }

    public void SelfDestructInASecond()
    {
        Destroy(this.gameObject, 1f);
    }
}
