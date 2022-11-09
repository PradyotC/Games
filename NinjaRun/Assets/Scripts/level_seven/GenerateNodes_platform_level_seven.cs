using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_platform_level_seven : MonoBehaviour
{
    public Transform target;
     public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    BoxCollider cubeBox;

    public Transform newPlayerBulletSpawn;
    
    public float newBulletSpeed = 10.0f;
    private double[] myNum =
    {
        // 0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24, 24.75, 26.25, 27, 27.75, 29.25, 30, 30.75, 32.25, 1.125, 2.625, 4.125, 5.625, 7.125, 8.625, 12.375, 13.875, 15.375, 16.875, 18.375, 19.875, 22.875, 26.625, 29.625, 32.625, 35.062
        // 0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75,  12, 13.5, 16.5, 19.5, 21, 23.25, 24, 24.75, 26.25, 27, 27.75, 29.25, 30, 32.625, 35.062, 37.025, 40, 42, 45, 47
        // 0.372, 0.745, 1.118, 1.49, 1.863, 2.236, 2.608, 2.981, 3.354, 3.726, 4.099, 4.472, 4.844, 5.217, 5.59, 5.962, 6.335, 6.708, 7.08, 7.453, 7.826, 8.198, 8.571, 8.944, 9.316, 9.689, 10.06, 10.43, 10.8, 11.18, 11.55, 11.92, 12.29, 12.67, 13.04, 13.41, 13.78, 14.16, 14.53, 14.9, 15.27, 15.65, 16.02, 16.39, 16.77, 17.14, 17.51, 17.88, 18.26, 18.63, 19.0, 19.37, 19.75, 20.12, 20.49, 20.86, 21.24, 21.61, 21.98, 22.36, 22.73, 23.1, 23.47, 23.85, 24.22, 24.59, 24.96, 25.34, 25.71, 26.08, 26.45, 26.83, 27.2, 27.57, 27.95, 28.32, 28.69, 29.06, 29.44, 29.81, 30.18, 30.55, 30.93, 31.3, 31.67, 32.04, 32.42, 32.79, 33.16, 33.54, 33.91, 34.28, 34.65, 35.03, 35.4, 35.77, 36.14, 36.52, 36.89, 37.27, 37.64, 38.02, 38.39, 38.76, 39.14, 39.51, 39.88, 40.25, 40.63, 41.0, 41.37, 41.75, 42.12, 42.49, 42.87, 43.24, 43.61, 43.98, 44.36, 44.73, 45.1, 45.48, 45.85, 46.22, 46.6, 46.97, 47.34, 47.71, 48.09, 48.46, 48.83, 49.21, 49.58
        // 2.236, 4.099, 5.962, 7.826, 9.689, 11.55, 13.41, 15.27, 17.14, 19.0, 20.86, 22.73, 24.59, 26.45, 28.32, 30.18, 32.04, 33.91, 35.77, 37.64, 39.51, 41.37, 43.24, 45.1, 46.97, 48.83
         3.354, 4.844, 6.335, 7.826, 9.316, 10.8, 12.29, 13.78, 15.27, 16.77, 18.26, 19.75, 21.24, 22.73, 24.22, 25.71, 27.2, 28.69, 30.18, 31.67, 33.16, 34.65, 36.14, 37.64, 39.14, 40.63, 42.12, 43.61, 45.1, 46.6, 48.09, 49.58
    };


    private string[] break_letters = new string[6] { "S", "T", "R", "E", "A", "K" };
    public static List<string> all_letter_word = new List<string>();

    private double[,] word_loc =
    {
        //{45.5,5.45,1},{90.45,2.45,-1}, {110,2.45,-1}, {180,5.45,-1}, {250,2.45,1}
        {45.5,2.45,1},{90.45,5.45,1}, {130,5.45,1}, {195,5.45,-1}, {270,2.45,-1}, {300,5.45,1}
    };

    void Start()
    {
        all_letter_word = new List<string>();
        var j = 0;
        for (int i = 0; i < myNum.Length; i++)
        {
            if (i % 5 == 0 && j < 6)
            {
                // var temp_el=break_letters.RemoveAt(0);
                // Debug.Log(break_letters[j]+"*********************************************"+ i);

                // GameObject cylinder_letter = Instantiate(Word_break_var);
                GameObject cylinder_letter = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                CapsuleCollider cylinder_Box;

                cylinder_Box = cylinder_letter.GetComponent<CapsuleCollider>();
                cylinder_Box.isTrigger = true;
                cylinder_Box.height = 1;

                cylinder_letter.AddComponent<TextMeshPro>();
                cylinder_letter.AddComponent<word_break_script_level_seven>();
                TextMeshPro TextDisplay = cylinder_letter.GetComponent<TextMeshPro>();
                cylinder_letter.transform.position = new Vector3((float)word_loc[j, 0], (float)word_loc[j, 1], (float)word_loc[j, 2]);

                // cylinder_letter.AddComponent<DScript_level1>();
                TextDisplay.text = break_letters[j];
                TextDisplay.fontSize = 10;
                TextDisplay.color = new Color32(255, 128, 0, 255);
                RectTransform placement = cylinder_letter.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);

                j += 1;
            }
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;
            int random = Random.Range(1,4);
            cube.transform.position = new Vector3((float)myNum[i]*10+1.8f, 8, target.transform.position.z);
            
            if (random == 1){
                cube.AddComponent<DScript_platform_level_seven>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_seven>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "W";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_platform_level_seven>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
