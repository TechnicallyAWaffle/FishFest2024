using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    int maxEnemies = 20;

    [SerializeField]
    int spawnRadius = 10;

    [SerializeField]
    int visualRadius = 5;

    [SerializeField]
    GameObject[] enemies;

    List<GameObject> aliveEnemies = new List<GameObject>();
    float previousSpawnTime = 0f;

    void Update()
    {
        if (aliveEnemies.Count < maxEnemies && Time.time > previousSpawnTime + Mathf.Abs(Mathf.Log(aliveEnemies.Count+1f)*0.5f))
        {
            GameObject enemy = Instantiate(enemies[0]);
            float enemyQuadrant = Random.value * 4;
            float enemyDistance = ((spawnRadius - visualRadius) * Random.value) + visualRadius;
            float posRandomizer = Random.value;
            Vector3 enemyCoords;

            if (enemyQuadrant < 1)
            {
                enemyCoords = new Vector3(Mathf.Sqrt(4f - Mathf.Pow(posRandomizer * 2f, 2)) * enemyDistance, posRandomizer * enemyDistance * 2, 0);
            }
            else if (enemyQuadrant < 2)
            {
                enemyCoords = new Vector3(Mathf.Sqrt(4f - Mathf.Pow(posRandomizer * 2f, 2)) * -enemyDistance, posRandomizer * enemyDistance * 2, 0);
            }
            else if (enemyQuadrant < 3)
            {
                enemyCoords = new Vector3(Mathf.Sqrt(4f - Mathf.Pow(posRandomizer * 2f, 2)) * enemyDistance, posRandomizer * enemyDistance * -2, 0);
            }
            else
            {
                enemyCoords = new Vector3(Mathf.Sqrt(4f - Mathf.Pow(posRandomizer * 2f, 2)) * -enemyDistance, posRandomizer * enemyDistance * -2, 0);
            }

            
            enemy.transform.position = Player.Instance.player.transform.position + enemyCoords;
            aliveEnemies.Add(enemy);
            previousSpawnTime = Time.time;
        }
    }
}
