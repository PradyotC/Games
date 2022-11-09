using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast_level_ayan : MonoBehaviour
{
    static public bool fast = false;
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
        Debug.Log("Sped Up");
        fast = true;
        gameObject.SetActive(false);
        }
        
    } 
}
