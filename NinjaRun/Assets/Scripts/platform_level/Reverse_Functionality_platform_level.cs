using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Reverse_Functionality_platform_level : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool reverseFunctionality = false;

    void Start()
    {
        reverseFunctionality = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider collision)
    {
        
        if (collision.name == "Ch24_nonPBR@Running"){
        reverseFunctionality = true;
        gameObject.SetActive(false);
        TextMeshPro reverseText =  GameObject.Find("ReverseText").GetComponent<TextMeshPro> ();
        reverseText.text = "";
        // reverseText.enabled = false;
        }
        
    } 
}
