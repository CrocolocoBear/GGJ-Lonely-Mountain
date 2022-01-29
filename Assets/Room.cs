using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject Fog;
    public Color color;

    public Renderer rend;
    private MaterialPropertyBlock propBlock;
    // Start is called before the first frame update
    void Start()
    {
        propBlock = new MaterialPropertyBlock();
    }

    // Update is called once per frame
    void Update()
    {
        rend.GetPropertyBlock(propBlock);

        propBlock.SetColor("_Color", color);
        rend.SetPropertyBlock(propBlock);
    }
}
