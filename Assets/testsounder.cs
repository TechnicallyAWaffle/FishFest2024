using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsounder : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager.PlaySong("song1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
