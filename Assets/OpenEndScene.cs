using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEndScene : MonoBehaviour
{
    public Interactable unlockItem;
    public bool played = false;
    public StartMenu menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockItem.unlocked && !played)
        {
            menu.EndPause();
            played = true;
        }
    }
}
