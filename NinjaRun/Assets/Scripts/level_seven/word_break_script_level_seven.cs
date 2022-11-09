using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class word_break_script_level_seven : MonoBehaviour
{

    GameObject Health;
    TextMeshPro objectText;
    GameObject Player_obj;
    // TextMeshPro word_text;

    // private List<string> all_letter_word = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        Player_obj=GameObject.Find("Ch24_nonPBR@Running");
        Health = GameObject.Find("Ch24_nonPBR@Running/HealthPlayer");
        objectText = Health.GetComponent<TextMeshPro> ();   
        // word_text =GameObject.Find("word_break").GetComponent<TextMeshPro> ();
    }


private void OnTriggerEnter(Collider other){
        if (other.name=="Ch24_nonPBR@Running") {
            Debug.Log(gameObject.GetComponent<TextMeshPro>().text);
            GenerateNodes_platform_level_seven.all_letter_word.Add(gameObject.GetComponent<TextMeshPro> ().text);
            Destroy(gameObject);
            if (GenerateNodes_platform_level_seven.all_letter_word.Count==6){
                // objectText.text = (int.Parse(objectText.text)+50).ToString();
                
                //Message for bonus wall
                // GameObject text_message = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                // // text_message.AddComponent<target>
                // text_message.AddComponent<TextMeshPro>();
                // text_message.AddComponent<word_break_script_level_seven>();
                // TextMeshPro TextDisplay = text_message.GetComponent<TextMeshPro>();
                // text_message.transform.position = new Vector3(Player_obj.transform.position.x, 6, 0);
                // text_message.transform.Translate((float)text_message.transform.position.x * 10.0f,6,0);

                // TextDisplay.text = "Pass through the wall to collect extra bonus point";
                // TextDisplay.fontSize = 10;
                // TextDisplay.color = new Color32(255, 128, 0, 255);

                // Debug.Log(GenerateNodes_platform_level_seven.all_letter_word);

//////////////////////////////////////////////////////////////////////////
//For False wall with bonus points
                GameObject false_cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                BoxCollider false_cube_Box;

                false_cube_Box = false_cube.GetComponent<BoxCollider>();
                false_cube_Box.isTrigger = true;

                false_cube.AddComponent<false_wall_script_level_seven>();

                // cylinder_letter.AddComponent<DScript_level1>();
                false_cube.GetComponent<Renderer>().material.color = new Color32(255, 128, 0, 255);
                // RectTransform placement = false_cube.GetComponent<RectTransform>();
                false_cube.transform.localScale = new Vector3(1f, 3f,4f);

                false_cube.transform.position = new Vector3(Player_obj.transform.position.x+20, 3, 0);
                
////////////////////////////////////////////////////////////////





            }
        Debug.Log(GenerateNodes_platform_level_seven.all_letter_word.Count);
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
