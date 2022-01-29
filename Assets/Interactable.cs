using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;

public class Interactable : MonoBehaviour
{
    public bool player1 = false;
    public bool used = true;
    public bool beingUsed = false;
    public bool usable = false;
    public bool disappear = false;
    public Interactable nextObject;
    private HighlightEffect highlighter;
    // Start is called before the first frame update
    void Start()
    {
        //childToHighlight = transform.GetChild(0).gameObject;
        highlighter = GetComponentInChildren<HighlightEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (usable && !used)
        {
            highlighter.highlighted = true;
        }
        else
        {
            highlighter.highlighted = false;
        }
    }

    public void Use()
    {
        used = true;
        if (nextObject != null)
        {
            nextObject.used = false;
        }
        if (disappear)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player1)
        {
            if (other.CompareTag("Player1"))
            {
                usable = true;
            }
            else
            {
                usable = false;
            }
        }
        else
        {
            if (other.CompareTag("Player2"))
            {
                usable = true;
            }
            else
            {
                usable = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player1)
        {
            if (other.CompareTag("Player1"))
            {
                usable = false;
            }
        }
        else
        {
            if (other.CompareTag("Player2"))
            {
                usable = false;
            }
        }

    }
}