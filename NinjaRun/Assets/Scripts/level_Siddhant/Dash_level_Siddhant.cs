using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_level_Siddhant : MonoBehaviour
{
    static public bool dash = false;
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
        Debug.Log("Dashing");
        dash = true;
        gameObject.SetActive(false);
        }
        
    } 
}
