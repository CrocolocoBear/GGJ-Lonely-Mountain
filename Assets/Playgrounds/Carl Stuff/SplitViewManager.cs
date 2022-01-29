using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitViewManager : MonoBehaviour
{
    [SerializeField] Transform mask1, mask2, cam1Tex, cam2Tex, separator;
    public int state = 0; //0 = vertical, 1 = diagonal, 2 = horizontal
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            mask1.eulerAngles = new Vector3(0, 0, 0);
            mask2.eulerAngles = new Vector3(0, 0, 0);
            cam1Tex.eulerAngles = new Vector3(0, 0, 0);
            cam2Tex.eulerAngles = new Vector3(0, 0, 0);
            separator.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (state == 1)
        {
            mask1.eulerAngles = new Vector3(0, 0, 60.7f);
            mask2.eulerAngles = new Vector3(0, 0, 60.7f);
            cam1Tex.eulerAngles = new Vector3(0, 0, 0f);
            cam2Tex.eulerAngles = new Vector3(0, 0, 0f);
            separator.eulerAngles = new Vector3(0, 0, 60.7f);
        }
        else if(state == 2)
        {
            mask1.eulerAngles = new Vector3(0, 0, 90f);
            mask2.eulerAngles = new Vector3(0, 0, 90f);
            cam1Tex.eulerAngles = new Vector3(0, 0, 0f);
            cam2Tex.eulerAngles = new Vector3(0, 0, 0f);
            separator.eulerAngles = new Vector3(0, 0, 90f);
        }
    }
}
