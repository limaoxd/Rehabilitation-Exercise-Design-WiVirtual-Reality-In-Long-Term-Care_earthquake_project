using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_Point : MonoBehaviour
{
    public GameObject[] Unit = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {
        GameObject Aim = GameObject.FindGameObjectWithTag("Player");
        var road_movement = Aim.GetComponent<Player_roadmovement>();
        
        for(int i = 0 ; i < Unit.Length ; ++i)
            road_movement.getDes(Unit[i].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
