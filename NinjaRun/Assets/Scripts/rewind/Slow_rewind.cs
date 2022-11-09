using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_rewind : MonoBehaviour
{
    static public bool slow = false;
    static public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        slow = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.name == "Ch24_nonPBR@Running"){
        Debug.Log("Slowed");
        slow = true;
        gameObject.SetActive(false);
        }
        
    } 

}
