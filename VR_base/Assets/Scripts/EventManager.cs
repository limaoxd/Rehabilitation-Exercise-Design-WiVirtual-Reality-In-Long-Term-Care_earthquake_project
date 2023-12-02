using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject[] Buildings = new GameObject[4];
    public GameObject[] Cars = new GameObject[5];
    public bool generate_car = false;
    private bool f = false;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.tag);
        if(other.tag != "MainCamera") return;
        f = true;
    }
    void Start()
    {
        if(generate_car){
            int now = Random.Range(0, 5);
            GameObject item = Instantiate(Cars[now], transform.position, transform.rotation);
            item.transform.SetParent(this.transform, false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(f){
            int index = Random.Range(0, Buildings.Length);
            Crack_Building crack_build = Buildings[index].GetComponent<Crack_Building>();

            if(crack_build) 
                crack_build.Active = true;
        }
        f = false;
    }
}
