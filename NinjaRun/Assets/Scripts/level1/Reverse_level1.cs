using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_level1 : MonoBehaviour
{
    static public bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.name == "Ch24_nonPBR@Running"){
        Debug.Log("Reversing");
        reverse = true;
        MetricsVariables.pickedup[2]++;
        gameObject.SetActive(false);
        }
        
    } 
}
