using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class MutationManager : MonoBehaviour
{
    private static MutationManager instance;

    private GameObject currentMutation;

    [SerializeField] private List<GameObject> mutationList = new List<GameObject>();
    [SerializeField] private Transform body;

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

    public void TickCurrentPassive()
    {
        if (currentMutation != null)
            currentMutation.GetComponent<IMutations>().MutationPassive();
        else
            Debug.Log("Mutation is null!");
    }

    public void ActivateCurrentAbility()
    {
        if (currentMutation != null)
            currentMutation.GetComponent<IMutations>().MutationActive();
        else
            Debug.Log("Mutation is null!");
    }

    public void UpdateMutation(IMutations incomingMutation)
    {
        currentMutation?.GetComponent<IMutations>().OnMutationEnd();
        Destroy(currentMutation);
        foreach (GameObject mutation in mutationList)
        {
            if (mutation.GetComponent<IMutations>().GetType() == incomingMutation.GetType())
            {
                Player.Instance.BodySpriteRenderer.sprite = mutation.GetComponent<IMutations>().BodySprite;
                Player.Instance.MouthSpriteRenderer.sprite = mutation.GetComponent<IMutations>().MouthSprite;
                currentMutation = Instantiate(mutation, body);
                currentMutation.GetComponent<IMutations>().SetPlayer(Player.Instance);
                currentMutation.GetComponent<IMutations>().OnMutationBegin();
            }
        }
    }

}
