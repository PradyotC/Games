using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_level_dash : MonoBehaviour
{
    static public bool reverseGravity = false;
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
        Debug.Log("Gravity Reversed");
        reverseGravity = true;
        gameObject.SetActive(false);
        }
        
    } 
}