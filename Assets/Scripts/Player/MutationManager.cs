using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MutationManager : MonoBehaviour
{
    private static MutationManager instance;
    public static MutationManager Instance
    {
        get
        {
            if (instance is null)
                Debug.Log("MutationManager is null");
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one MutationManager in scene");
        instance = this;
    }
}
