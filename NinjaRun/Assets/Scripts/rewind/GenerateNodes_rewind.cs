using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_rewind : MonoBehaviour
{
    private int numNotes = 30;
    public Transform target;
     public GameObject newBulletPrefab;
    public Transform newBulletSpawn;

    public Transform newPlayerBulletSpawn;
    
    public float newBulletSpeed = 10.0f;
    private double[] myNum =
    {
        0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24, 24.75, 26.25, 27, 27.75, 29.25, 30, 30.75, 32.25, 1.125, 2.625, 4.125, 5.625, 7.125, 8.625, 12.375, 13.875, 15.375, 16.875, 18.375, 19.875, 22.875, 26.625, 29.625, 32.625, 35.062
    };
	
    void Start()
    {
        for (int i = 0; i < myNum.Length; i+=3)
        {
            if (myNum[i] > 5){
                continue;
            }
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(cube.GetComponent<Collider>());
            // cube.AddComponent<BoxCollider>();
			
            //NoteMaker.transform.SetParent(cube);
            int random = Random.Range(1,2);
            //int random2 = Random.Range(5,10);
            
            cube.transform.position = new Vector3((float)myNum[i]*10+1.8f, 3, 2);
            
            if (random == 1){
                cube.AddComponent<DScript_rewind>();
                //  cube.GetComponent<DScript_rewind>().newBulletPrefab = newBulletPrefab;
                // cube.GetComponent<DScript_rewind>().newBulletSpawn = newBulletSpawn;
                // cube.GetComponent<DScript_rewind>().newBulletSpeed = newBulletSpeed;
                // cube.GetComponent<DScript_rewind>().newPlayerBulletSpawn = newPlayerBulletSpawn;
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "E";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            // else if(random2 == 11){
            //     cube.AddComponent<script_9>();
            //     cube.AddComponent<TextMeshPro>();
            //     TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
            //     TextDisplay.text = "9";
            //     TextDisplay.fontSize = 10;
            //     RectTransform placement = cube.GetComponent<RectTransform>();
            //     placement.sizeDelta = new Vector2(1f, 1f);
            // }
            else if (random == 2){
                cube.AddComponent<SScript_rewind>();
                //  cube.GetComponent<SScript_rewind>().newBulletPrefab = newBulletPrefab;
                // cube.GetComponent<SScript_rewind>().newBulletSpawn = newBulletSpawn;
                // cube.GetComponent<SScript_rewind>().newBulletSpeed = newBulletSpeed;
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "2";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_rewind>();
                //  cube.GetComponent<AScript_rewind>().newBulletPrefab = newBulletPrefab;
                // cube.GetComponent<AScript_rewind>().newBulletSpawn = newBulletSpawn;
                // cube.GetComponent<AScript_rewind>().newBulletSpeed = newBulletSpeed;
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "3";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else{
                cube.AddComponent<WScript_rewind>();
                 cube.GetComponent<WScript_rewind>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<WScript_rewind>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<WScript_rewind>().newBulletSpeed = newBulletSpeed;
                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "4";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
        }
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = new Vector3(0, 0.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
