using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Color color;
    private bool roomDiscovered = false;
    public bool player1;
    public Collider coll;
    private int alpha;
    public Renderer[] rend;
    private MaterialPropertyBlock propBlock;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentsInChildren<Renderer>();
        propBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Renderer render in rend)
        {
            render.GetPropertyBlock(propBlock);
            propBlock.SetColor("_BaseColor", color);
            render.SetPropertyBlock(propBlock);
        }
        if (roomDiscovered && color.a > 0)
        {
            color.a -= 0.01f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (player1)
        {
            if (other.CompareTag("Player1"))
            {
                roomDiscovered = true;
            }
        }
        else
        {
            if (other.CompareTag("Player2"))
            {
                roomDiscovered = true;
            }
        }
    }
}
