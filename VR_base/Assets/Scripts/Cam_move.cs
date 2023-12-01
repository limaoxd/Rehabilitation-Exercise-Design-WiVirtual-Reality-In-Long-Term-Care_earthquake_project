using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_move : MonoBehaviour
{
    public float vel = 5f;
    public float boundary = 2f;
    private bool left = false;
    private bool right = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left = false;
        right = false;
        if(Input.GetKey(KeyCode.A)) left = true;
        if(Input.GetKey(KeyCode.D)) right = true;

        if(transform.localPosition.x >= boundary) right = false;
        else if(transform.localPosition.x <= -boundary) left = false;    

        if(right){
            transform.localPosition += transform.localRotation * new Vector3(vel * Time.deltaTime, 0, 0);
        }
        else if(left){
            transform.localPosition -= transform.localRotation * new Vector3(vel * Time.deltaTime, 0, 0);
        }
    }
}
