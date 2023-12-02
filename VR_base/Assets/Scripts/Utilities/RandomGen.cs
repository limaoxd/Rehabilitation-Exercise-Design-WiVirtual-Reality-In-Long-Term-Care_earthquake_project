using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public Material[] mets;
    // Start is called before the first frame update
    void Start()
    {
        int ind = Random.Range(0, mets.Length);
        this.GetComponent<MeshRenderer>().material = mets[ind];

        float xpos = 2.5f - 5f * Random.Range(0, 2);
        this.transform.localPosition = new Vector3(xpos, 1, Random.Range(-12f, 12f));
        this.transform.eulerAngles = new Vector3(0, Random.Range(-90f, 90f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
