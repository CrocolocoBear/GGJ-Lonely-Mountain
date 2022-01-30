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
    public bool textBoxActive = false;
    public bool usedThisRound = false;
    public bool unlocked = false;
    public Interactable nextObject;
    private HighlightEffect highlighter;
    public TextBox textBox;
    /*
    Textbox will work by gameobjects who have switch beingUsed to true, 
    if alpha of Textbox is less than 1 they fade in
    player gets frozen
    they have to interact again to remove it
    if used and alpha more than 0, fade out
    */
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
        if (!textBox.moreLines && !usedThisRound)
        {
            used = true;
            unlocked = true;
            usedThisRound = true;
            if (nextObject != null)
            {
                nextObject.used = false;
            }
            if (disappear)
            {
                gameObject.SetActive(false);
                textBox.box.SetActive(false);
            }
        }
        else if (textBoxActive && textBox.moreLines && !usedThisRound)
        {
            textBox.NextLine();
            usedThisRound = true;
        }
        else if(!textBoxActive && !usedThisRound)
        {
            beingUsed = true;
            textBoxActive = true;
            textBox.box.SetActive(true);
            textBox.text.text = textBox.lines[0];
            usedThisRound = true;
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
