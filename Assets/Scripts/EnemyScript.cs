using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyLevel = 5;
    
    Boolean nearPlayer = false;
    Rigidbody2D enemyrb2d;
    LevelManager levelManager;
    Transform playerTransform;
    Vector2 playerPos;
    Vector2 currEnemyPos;
    Vector2 spawnPos;
    float angleFromPlayer;
    Vector2 directionTowardPlayer;
    Vector2 directionAwayFromPlayer;
    private void Awake()
    {
        enemyrb2d = GetComponent<Rigidbody2D>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnPos = new(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new(playerTransform.position.x, playerTransform.position.y);
        currEnemyPos = new(transform.position.x,transform.position.y);

        directionTowardPlayer = playerPos - currEnemyPos;
        directionAwayFromPlayer = currEnemyPos - playerPos;

        angleFromPlayer = GetAngle(directionAwayFromPlayer);


    }

    private void FixedUpdate()
    {
        if (levelManager.CheckLevel(enemyLevel))
        {
            FleeingBehaviour();
        }
        else { 
            ChasingBehaviour();
        }

        //levelManager.CheckLevel(int level) returns true for both when the enemy level is higher AND for when it the SAME so can't ever be called using it NeutralBehaviour();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) //Player Layer is 3
        {
            nearPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) //Player Layer is 3
        {
            nearPlayer = false;
        }

    }
    private float GetAngle(Vector2 direction)
    {
        float angleRad = Mathf.Atan2(direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;

        return angleDeg;
    }

    public virtual void FleeingBehaviour() {
        if (nearPlayer)
        {
            enemyrb2d.velocity = directionAwayFromPlayer.normalized * 5;
            transform.rotation = Quaternion.Euler(0, 0, angleFromPlayer + 180);
        }
        else
        {
            enemyrb2d.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    public virtual void ChasingBehaviour()
    {
        if (nearPlayer)
        {
            enemyrb2d.velocity = directionTowardPlayer.normalized * 5;
            transform.rotation = Quaternion.Euler(0, 0, angleFromPlayer);
        }
        else
        {
            enemyrb2d.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    public virtual void NeutralBehaviour()
    {
        enemyrb2d.velocity = Vector2.zero;

        if (nearPlayer)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleFromPlayer);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    public virtual void PheromoneReaction() {
        Debug.Log("Enemy in Pheromones");
    }
}
