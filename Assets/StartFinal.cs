using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinal : MonoBehaviour
{
    public Interactable unlockItem;
    public AudioSource audioSrc;
    public AudioClip scream;
    public bool played = false;
    public SplitViewManager splitter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockItem.unlocked && !played)
        {
            audioSrc.clip = scream;
            audioSrc.Play();
            splitter.finalScene = true;
            played = true;
        }
    }
}
