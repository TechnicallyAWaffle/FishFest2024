using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    protected MutationBase mutationReward;
    
	public int enemyLevel = 5;
	
    Boolean nearPlayer = false;
    Rigidbody2D enemyrb2d;
    Transform playerTransform;
    Vector2 playerPos;
    Vector2 currEnemyPos;
    Vector2 spawnPos;
    float angleFromPlayer;
    Vector2 directionTowardPlayer;
    Vector2 directionAwayFromPlayer;
    [SerializeField] protected float defaultSpeed;
    protected float speed;
    protected bool pheromoned;
    public bool isAlpha = false;
    public bool isInvincible = false;

    //Timer variables
    private float time = 5;

    private void Awake()
    {
        enemyrb2d = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawnPos = new(transform.position.x, transform.position.y);
        speed = defaultSpeed;
        pheromoned = false;
        //testing
        enemyLevel = 1;
    }

    private void Start()
    {
        Debug.Log("TODO: Gets assigned mutation on start, change to when eaten");
        MutationManager.Instance.UpdateMutation(mutationReward);
    }

    public void SetupEnemy(bool isAlpha, int enemyLevel)
    {
        this.isAlpha = isAlpha;
        this.enemyLevel = enemyLevel;
        if (this.isAlpha)
            BecomeAlpha();
    }

    private void BecomeAlpha()
    {
        enemyLevel = 999;
        gameObject.transform.localScale = new Vector3(2, 2); //This will be bigger later
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
        
        if (nearPlayer)
        {
            if (LevelManager.Instance.CheckLevel(enemyLevel))
            {
                Debug.Log("Near player and player level higher");
                if (pheromoned)
                    ChasingBehaviour();
                else
                    FleeingBehaviour();
            }
            else
            {
                Debug.Log("Near player and player level is lower");
                if (pheromoned)
                    FleeingBehaviour();
                else
                    ChasingBehaviour();
            }
        }
        else
        {
            NeutralBehaviour();
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
            enemyrb2d.velocity = directionAwayFromPlayer.normalized * speed;
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
            enemyrb2d.velocity = directionTowardPlayer.normalized * speed;
            transform.rotation = Quaternion.Euler(0, 0, angleFromPlayer);
        }
        else
        {
            enemyrb2d.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    public virtual void PheromoneBehaviour()
    {
        if(isAlpha)
            //trigger dialogue
        StartCoroutine(BasePheromoneBehaviour());
    }

    private IEnumerator BasePheromoneBehaviour()
    {
        pheromoned = true;
        speed = speed / 2;
        yield return new WaitForSeconds(1.5f);
        speed = defaultSpeed;
        pheromoned = false;
    }

    public virtual void NeutralBehaviour()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            enemyrb2d.velocity = new Vector2(UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360)).normalized * speed;
            float newTime = UnityEngine.Random.Range(2, 10);
            time = newTime;
        }

    }
}
