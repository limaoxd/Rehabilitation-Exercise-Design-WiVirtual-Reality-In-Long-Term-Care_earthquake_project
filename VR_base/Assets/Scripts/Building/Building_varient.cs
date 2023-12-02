using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_varient : MonoBehaviour
{
    public GameObject[] Unit = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        int ind = Random.Range(0, Unit.Length);
        Unit[ind].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
