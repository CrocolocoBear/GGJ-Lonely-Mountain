using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWomanvisible : MonoBehaviour
{
    public Interactable unlockItem;
    public GameObject woman;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockItem.unlocked && !woman.activeInHierarchy)
        {
            woman.SetActive(true);
        }
    }
}
