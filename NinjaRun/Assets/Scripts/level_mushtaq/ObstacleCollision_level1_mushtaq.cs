using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleCollision_level1_mushtaq : MonoBehaviour
{

    GameObject Health;
    TextMeshPro objectText;
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!Reverse_level1.reverse && collision.name == "Ch24_nonPBR@Running" && !Dash_level1.dash)
        {
            objectText.text = (int.Parse(objectText.text) - 1).ToString();
            MetricsVariables.loseHealth();
        }
    }
}
