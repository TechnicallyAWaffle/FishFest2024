using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static event Action levelUpEvent;
    public int playerLevel { get; private set; }

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
        levelUpEvent();
    }
}
