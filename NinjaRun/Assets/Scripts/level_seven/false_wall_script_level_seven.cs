using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class false_wall_script_level_seven : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Health;
    TextMeshPro objectText;



    // public GameObject false_wall;

    void Start()
    {
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
    }

    private void OnTriggerEnter(Collider other){
        if (other.name=="Ch24_nonPBR@Running") {
            Debug.Log(other.name);
            Destroy(gameObject);
            objectText.text = (int.Parse(objectText.text)+70).ToString();
        }
        // else{
        //     Debug.Log(other.name);
        //     Destroy(gameObject);
        // }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
