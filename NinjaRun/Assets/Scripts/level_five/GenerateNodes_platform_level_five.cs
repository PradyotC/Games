using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_platform_level_five : MonoBehaviour
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
        // 0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24, 24.75, 26.25, 27, 27.75, 29.25, 30, 30.75, 32.25
        0.487, 0.975, 1.463, 2.439, 2.926, 3.414, 4.39, 4.878, 5.365, 6.341, 6.829, 7.317, 8.292, 8.78, 9.268, 10.24, 10.73, 11.21, 12.19, 12.68, 13.17, 14.14, 14.63, 15.12, 15.6, 16.58, 17.07, 17.56, 18.53, 19.02, 19.51, 20.48, 20.97, 21.46, 22.43, 22.92, 23.41, 24.39, 24.87, 25.36, 26.34, 26.82, 27.31, 28.29, 28.78, 29.26, 30.24, 30.73, 31.21
        // 33.17, 33.65, 34.14, 34.63, 35.12, 35.6, 36.09, 36.58, 37.07, 37.56, 38.04, 38.53, 39.02, 39.51, 40.0, 40.48, 40.97, 41.46, 41.95, 42.43, 42.92, 43.41, 43.9, 44.39, 44.87, 45.36, 45.85, 46.34, 46.82, 47.31, 47.8, 48.29
    };

	
    void Start()
    {
        for (int i = 0; i < myNum.Length; i++)
        {
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;
            int random = Random.Range(1,4);
            cube.transform.position = new Vector3((float)myNum[i]*10+1.8f, 8, target.transform.position.z);
            
            if (random == 1){
                cube.AddComponent<DScript_platform_level_five>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_five>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "W";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }

            else if (random == 3){
                cube.AddComponent<AScript_platform_level_five>();
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
