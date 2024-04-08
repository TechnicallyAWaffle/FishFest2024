using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static event Action levelUpEvent;
    public int playerLevel { get; private set; }

    // current amount of xp our player has
    private float currentXp;
    // xp required to get to the next level
    private float xpRequirement; 

    [SerializeField] private float levelRandomLowerBound, levelRandomUpperBound;

    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance is null)
                Debug.Log("LevelManager is null");
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one MutationManager in scene");
        instance = this;

        // initial value of variables
        playerLevel = 1;
        UpdateXpRequirement();
    }

    public bool CheckLevel(int levelToCompare) 
    {
        return playerLevel >= levelToCompare ? true : false;
    }

    public void AddXp(float amount)
    {
        currentXp += amount;
        // Debug.Log("Level " + playerLevel);
        // Debug.Log("Added xp " + amount + ", xp requirement " + xpRequirement);
        LevelIfPossible();
        // Debug.Log("Level " + playerLevel);
    }

    public void LevelUp()
    {
        playerLevel += 1;
        currentXp -= xpRequirement;
        UpdateXpRequirement();

        levelUpEvent?.Invoke();
    }

    private void UpdateXpRequirement()
    {
        xpRequirement = (playerLevel+1)*UnityEngine.Random.Range(levelRandomLowerBound, levelRandomUpperBound);
    }

    private void LevelIfPossible()
    {
        if(currentXp >= xpRequirement) 
        {
            LevelUp();
            LevelIfPossible(); // in case we level up multiple times at once i guess
        }
    }
}
