using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour
{
    [SerializeField] public string[] lines;
    public GameObject box;
    int index = 0;
    public TMP_Text text;
    public bool moreLines = true;
    // Start is called before the first frame update
    void Start()
    {
        //text.text = lines[index];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NextLine()
    {
        index += 1;
        text.text = lines[index];
        if (lines.Length == index + 1)
        {
            moreLines = false;
        }
    }
}
