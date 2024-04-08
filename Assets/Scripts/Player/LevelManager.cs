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
        playerLevel = 1;
        if (instance != null)
            Debug.LogError("More than one MutationManager in scene");
        instance = this;
    }

    public bool CheckLevel(int levelToCompare) 
    {
        if (playerLevel >= levelToCompare)
            return true;
        else
            return false;
    }

    public void LevelUp()
    {
        playerLevel += 1;
        currentXp -= xpRequirement;
        xpRequirement = (playerLevel+1)*(UnityEngine.Random.Range(levelRandomLowerBound, levelRandomUpperBound));

        levelUpEvent();
    }

    public void AddXp(float amount)
    {
        currentXp += amount;
        Debug.Log("Added xp " + amount + ", xp requirement " + xpRequirement);
        LevelIfPossible();
    }

    private void LevelIfPossible()
    {
        if(currentXp >= xpRequirement) LevelUp();
    }
}
