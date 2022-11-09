using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_platform_level_six : MonoBehaviour
{
    public Transform target;
     public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    BoxCollider cubeBox;

    public Transform newPlayerBulletSpawn;
    
    public float newBulletSpeed = 10.0f;
    private double[] myNum =
    {
        1.406, 1.875, 2.343, 2.812, 3.281,  5.156, 5.625, 6.093, 6.562, 7.031, 7.5, 9.375, 9.843, 10.31, 10.78, 11.25, 11.71, 12.18, 14.06, 14.53, 15.0, 15.46, 15.93, 16.4, 16.87, 17.34, 17.81, 18.28, 18.75, 19.21, 19.68, 22.03, 22.5, 22.96, 23.43, 23.9, 24.37, 24.84, 25.31, 25.78, 27.65, 28.12, 28.59, 29.06, 29.53, 30.0, 30.46, 30.93, 31.4, 31.87, 32.34, 34.21, 34.68, 35.15, 35.62, 36.09, 36.56, 37.03, 37.5, 37.96, 38.43, 38.9, 41.25, 41.71, 42.18, 42.65, 43.12, 43.59, 44.06, 44.53, 45.0, 45.46, 45.93, 46.4
    };


    private string[] break_letters = new string[5]{ "B","R","E","A","K" };
    public static List<string> all_letter_word = new List<string>();

    private double[,] word_loc =
    {
        {45.5,5.45,1},{90.45,2.45,-1}, {110,2.45,-1}, {180,5.45,-1}, {250,2.45,1}
    };


	
    void Start()
    {
        all_letter_word = new List<string>();
        var j=0;
        Debug.Log(myNum.Length);
        for (int i = 0; i < myNum.Length; i++)
        {
            if (i%5==0 && j<5){
                // var temp_el=break_letters.RemoveAt(0);
                // Debug.Log(break_letters[j]+"*********************************************"+ i);
                
                // GameObject cylinder_letter = Instantiate(Word_break_var);
                GameObject cylinder_letter = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                CapsuleCollider cylinder_Box;

                cylinder_Box = cylinder_letter.GetComponent<CapsuleCollider>();
                cylinder_Box.isTrigger = true;
                cylinder_Box.height=1;

                cylinder_letter.AddComponent<TextMeshPro>();
                cylinder_letter.AddComponent<word_break_script>();
                TextMeshPro TextDisplay = cylinder_letter.GetComponent<TextMeshPro>();
                cylinder_letter.transform.position = new Vector3((float)word_loc[j,0], (float)word_loc[j,1], (float)word_loc[j,2]);

                // cylinder_letter.AddComponent<DScript_level1>();
                TextDisplay.text = break_letters[j];
                TextDisplay.fontSize = 10;
                TextDisplay.color = new Color32(255, 128, 0, 255);
                RectTransform placement = cylinder_letter.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);

                j+=1;
            }

            if (i%2==0){
GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;
            int random = Random.Range(1,4);
            cube.transform.position = new Vector3((float)myNum[i]*10+1.8f, 8, target.transform.position.z);
            
            if (random == 1){
                cube.AddComponent<DScript_platform_level_six>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_six>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "W";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_platform_level_six>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "Q";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else{
                cube.AddComponent<WScript_platform_level>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "4";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            }
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
