using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Collider coll;
    public bool player1;
    bool open = false;
    public float rotation = 0;
    public float origRot;
    //when the player gets close, rotate 90 degrees, then stop checking  
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        origRot = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (open && rotation < 90f)
        {
            rotation += 2f;
        }
        else if(!open && rotation > 0)
        {
            rotation -= 2f;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, origRot + rotation, transform.eulerAngles.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player1)
        {
            if (other.CompareTag("Player1"))
            {
                open = true;
                
            }
        }
        else
        {
            if (other.CompareTag("Player2"))
            {
                open = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player1)
        {
            if (other.CompareTag("Player1"))
            {
                open = false;
                
            }
        }
        else
        {
            if (other.CompareTag("Player2"))
            {
                open = false;
            }
        }
    }
}
