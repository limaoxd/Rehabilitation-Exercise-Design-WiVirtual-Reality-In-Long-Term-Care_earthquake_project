using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int max_life = 5;
    public int life = 5;
    public float hurt_time = 2f;
    // Start is called before the first frame update
    public void Reset(){
        life = max_life;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Obstacle" || hurt_time > 0) return;
        hurt_time = 2f;
        life -= 1;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hurt_time > 0) hurt_time -= Time.deltaTime;
        else hurt_time = 0;
    }
}
