using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Interactable unlockItem;
    public float rotation = 0;
    public float origRot;
    // Start is called before the first frame update
    void Start()
    {
        origRot = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (unlockItem.unlocked)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, origRot + rotation, transform.eulerAngles.z);
        }
    }
}
