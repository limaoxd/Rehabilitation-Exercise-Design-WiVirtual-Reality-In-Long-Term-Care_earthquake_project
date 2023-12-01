using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_roadmovement: MonoBehaviour
{
    public Queue<Vector3> Destinations = new Queue<Vector3>();
    public float Vel = 5f;
    public float smoothTime = 10f;
    public float bias = 0.5f;
    private GameObject cam;

    public void getDes(Vector3 pos){
        Destinations.Enqueue(pos);
        cam = Camera.main.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Destinations.Count > 0){
            Vector3 front = Destinations.Peek();
            if(Vector3.Distance(front, this.transform.position) < bias)
                Destinations.Dequeue();
            else{
                Vector3 vector = (front - this.transform.position).normalized;
                this.transform.position += vector * Vel * Time.deltaTime;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(vector), smoothTime * Time.deltaTime);
            }   
        }
    }
}
