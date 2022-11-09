using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_platform_level_two : MonoBehaviour
{
    public Transform target;
     public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    BoxCollider cubeBox;

    public Transform newPlayerBulletSpawn;
    
    public float newBulletSpeed = 10.0f;
    public static int cnt = 0;
    private double[] myNum =
    {
        0.618, 1.237, 1.855, 2.474, 3.092, 3.711, 4.329, 4.948, 5.567, 6.185, 6.804, 7.422, 8.041, 8.659, 9.278, 9.896, 10.51, 11.13, 11.75, 12.37, 12.98, 13.6, 14.22, 14.84, 15.46, 16.08, 16.7, 17.31, 17.93, 18.55, 19.17, 19.79, 20.41, 21.03, 21.64, 22.26, 22.88, 23.5, 24.12, 24.74, 25.36, 25.97, 26.59, 27.21, 27.83, 28.45, 29.07, 29.69, 30.3, 30.92, 31.54, 32.16, 32.78, 33.4, 34.02, 34.63, 35.25, 35.87, 36.49
    };
	
    void Start()
    {
        for (int i = 0; i < myNum.Length; i+=3)
        {
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;
            int random = Random.Range(1,3);
            cube.transform.position = new Vector3((float)myNum[i]*10+1.8f, 3, 2);
            
            if (random == 1){
                cube.AddComponent<DScript_platform_level_two>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_two>();
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "W";
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
