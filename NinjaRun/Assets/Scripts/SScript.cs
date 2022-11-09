using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SScript : MonoBehaviour
{
    GameObject Health;
    TextMeshPro objectText;
    GameObject HealthEnemy;
    TextMeshPro objectTextEnemy;
    public bool canBePressed;
    public KeyCode keyToPress = KeyCode.Alpha2;
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();
        HealthEnemy = GameObject.Find("Ch24_nonPBR@RunningEnemy/HealthEnemy");
        objectTextEnemy = HealthEnemy.GetComponent<TextMeshPro> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                objectTextEnemy.text = (int.Parse(objectTextEnemy.text)-10).ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "segment4")
        {
            canBePressed = true;
        }
        if(other.name == "segment5")
        {
           objectText.text = (int.Parse(objectText.text)-10).ToString();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "segment2")
        {
            canBePressed = false;
        }
    }
}
