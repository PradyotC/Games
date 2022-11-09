using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_platform_level_three : MonoBehaviour
{
    public Transform target;
     public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    BoxCollider cubeBox;

    public Transform newPlayerBulletSpawn;
    
    public float newBulletSpeed = 10.0f;
    private double[] myNum =
    {
        // 0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24
        3.564, 4.752, 6.534, 8.316, 8.91, 10.69, 11.28, 11.88, 13.66, 14.85, 16.03, 17.82, 19.0, 20.19, 21.38, 22.57, 23.16,24.35, 26.13, 27.92, 29.1, 29.7, 31.48, 32.67, 33.86, 
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
                cube.AddComponent<DScript_platform_level_three>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_three>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "W";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_platform_level_three>();
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
