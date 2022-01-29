using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitViewManager : MonoBehaviour
{
    [SerializeField] Transform mask1, mask2, cam1Tex, cam2Tex, separator, separator2, player1, player2;
    public Vector2 rot = new Vector2(0,0);
    //public int state = 0; //0 = vertical, 1 = diagonal, 2 = horizontal
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot.x = (player2.position - player1.position).normalized.z;
        rot.y = -(player2.position - player1.position).normalized.x;
        //rot = Vector3.Cross(player2.position - player1.position, Vector3.forward).normalized;
        if (rot.y < 0)
        {
            separator.rotation = Quaternion.Euler(0, 0, (rot.x * 360)/4);
            separator2.rotation = Quaternion.Euler(90, 0, (rot.x * 360)/4);
            mask1.rotation = Quaternion.Euler(0, 0, (rot.x * 360) / 4);
            mask2.rotation = Quaternion.Euler(0, 0, (rot.x * 360) / 4);
        }
        else
        {
            separator.rotation = Quaternion.Euler(0, 0, -(rot.x * 360)/4);
            separator2.rotation = Quaternion.Euler(90, 0, -(rot.x * 360)/4);
            mask1.rotation = Quaternion.Euler(0, 0, 180-(rot.x * 360) / 4);
            mask2.rotation = Quaternion.Euler(0, 0, 180-(rot.x * 360) / 4);
        }
        cam1Tex.eulerAngles = new Vector3(0, 0, 0f);
        cam2Tex.eulerAngles = new Vector3(0, 0, 0f);

        /*
        if (state == 0)
        {
            
            mask1.eulerAngles = new Vector3(0, 0, 0f);
            mask2.eulerAngles = new Vector3(0, 0, 0f);
            cam1Tex.eulerAngles = new Vector3(0, 0, 0f);
            cam2Tex.eulerAngles = new Vector3(0, 0, 0f);
            separator.eulerAngles = new Vector3(0, 0, 0f);
            
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
        */
    }
}