using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse_rewind : MonoBehaviour
{
    static public bool reverse = false;
    static public bool test = true; ////////////Rewind Test Variable

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
            gameObject.SetActive(false);
        }
        
    }

}
