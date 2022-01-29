using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isFirstCamera = false;
    [SerializeField] private SplitViewManager splitMng;
    [SerializeField] private Vector3 regularOffset, offset1, offset2, offset3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (splitMng.state == 0)
        {
            transform.position = regularOffset + offset1;
        }
        else if (splitMng.state == 1)
        {
            transform.position = regularOffset + offset2;
        }
        else if (splitMng.state == 2)
        {
            transform.position = regularOffset + offset3;
        }
    }
}
