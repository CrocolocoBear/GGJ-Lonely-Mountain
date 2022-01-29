using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool isFirstCamera = false;
    public float zoomLevel = 2.5f;
    [SerializeField] private SplitViewManager splitMng;
    [SerializeField] private Vector3 minOffset, maxOffset;
    [SerializeField] Transform player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.position.magnitude > player2.position.magnitude)
        {
            transform.position = -transform.forward * player1.position.magnitude * zoomLevel;
        }
        else
        {
            transform.position = -transform.forward * player2.position.magnitude * zoomLevel;
        }
        /*
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
        */
    }
}
