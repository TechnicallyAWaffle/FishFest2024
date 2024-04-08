using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PheromoneCloud : MonoBehaviour
{
    [SerializeField]
    private float cloudDuration = 2f;
    [SerializeField]
    private float cloudDecayRate = 0.5f;
    [SerializeField]
    private float fadeDuration = 1.0f;
    [SerializeField]
    private float opacityReductionRate = 0.5f;
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        DespawnSequence();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
            enemyScript.PheromoneReaction();
        }

    }

    private void DespawnSequence() {
        cloudDuration -= cloudDecayRate * Time.deltaTime;

        if (cloudDuration <= fadeDuration) { Debug.Log("Cloud should be fading."); }
        if (cloudDuration <= 0) { Destroy(gameObject); }//Problematic
    }
}
