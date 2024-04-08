using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Bite : MonoBehaviour
{ 
    [Header("Tuning")]
    // the lower and upper bounds in the formula
    [SerializeField] private int randomEatXPLowerBound;
    [SerializeField] private int randomEatXPUpperBound;
    
    // minimum time to wind up a bite 
    [SerializeField] private float maxBiteWindupTime;
    // radius of bite around player
    [SerializeField] private float biteRadius;
    
    // reference variabl lol
    private LevelManager levelManager;

    [Header("Debug")]
    // true if biting (rmb held), false otherwise
    [SerializeField] private bool biting;   
    // current bite timer
    [SerializeField] private float biteTimer;

    void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    public void StartBite()
    {
        biteTimer = 0f;
        biting = true;
    }

    public void StopBite()
    {
        biting = false;

        // cap it to 1
        float biteLevel = math.min(biteTimer/maxBiteWindupTime, 1);
        Collider2D[] bittenColliders = new Collider2D[0]; 
        bittenColliders = new Collider2D[Physics2D.OverlapCircleNonAlloc(transform.position, biteRadius, bittenColliders)];
        Debug.DrawRay(transform.position, biteRadius * Vector3.right, Color.red, 1f);
        Debug.DrawRay(transform.position, biteRadius * Vector3.left, Color.red, 1f);
        Debug.DrawRay(transform.position, biteRadius * Vector3.up, Color.red, 1f);
        Debug.DrawRay(transform.position, biteRadius * Vector3.down, Color.red, 1f);

        foreach(Collider2D collider in bittenColliders)
        {
            Debug.Log(collider.gameObject.name);
            TryBite(collider, biteLevel);
        }
            
    }

    // helper for stopbite
    // processes a single collider2d to be bitten ig
    private void TryBite(Collider2D collider, float biteLevel)
    {
        EnemyScript enemyScript;
        // if the collided is an enemy
        if(collider.TryGetComponent<EnemyScript>(out enemyScript))
        {
            int level = enemyScript.enemyLevel;
            if(biteLevel >= level) 
                DoBite(enemyScript);
        }
    }

    // helper fr trybite
    // only run once we're sure we can actually bite the enemy
    // destroy the gameobject and add the xp to our levelmanager
    private void DoBite(EnemyScript enemyScript)
    {
        int level = enemyScript.enemyLevel;
        Destroy(enemyScript.transform.gameObject);

        levelManager.AddXp(level * UnityEngine.Random.Range(randomEatXPLowerBound, randomEatXPUpperBound));
    }

    // Update is called once per frame
    public void GameUpdate()
    {
        if(!biting) return;

        biteTimer += Time.deltaTime;
    }
}
