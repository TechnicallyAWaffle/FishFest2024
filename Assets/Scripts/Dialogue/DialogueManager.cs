using System.Collections;
using System.Collections.Generic;
using TMPro;
using Ink.Runtime;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject playerDialoguePanel;
    [SerializeField] private TextMeshProUGUI playerDialogueText;

    public GameObject enemyDialoguePanel;
    public GameObject enemyDialogueText;


    [SerializeField] private TextAsset dialogue;

    private Story currentStory;
    private string currentSpeaker;

    private bool dialogueIsPlaying;

    private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get
        {
            if (instance is null)
                Debug.Log("DialogueManager is null");
            return instance;
        }
    }
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("More than one DialogueManager in scene");
        instance = this;
        dialogueIsPlaying = false;
    }

    public void EnterDialogueMode()
    {
        currentStory = new Story(dialogue.text);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);
       // dialogueText.text = "";
        currentStory.UnbindExternalFunction("SetSpeaker");
        currentSpeaker = "";
    }

    private void SwitchSpeaker(string currentSpeaker)
    {
        //do stuff and cry!!!
        Debug.Log("speaker switched to " + currentSpeaker);
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //if(currentSpeaker)
            //dialogueText.text = currentStory.Continue();
            if (currentStory.currentTags[0] != currentSpeaker)
            {
                currentSpeaker = currentStory.currentTags[0];
                SwitchSpeaker(currentSpeaker);
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }
}
