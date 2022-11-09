using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_level2 : MonoBehaviour
{
    private int numNotes = 30;
    public Transform target;
    public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    public float newBulletSpeed = 10.0f;
    public Transform newPlayerBulletSpawn;

	
    void Start()
    {
        for (int i = 1; i <= numNotes; i++)
        {
            
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(cube.GetComponent<Collider>());
            // cube.AddComponent<BoxCollider>();
			
            //NoteMaker.transform.SetParent(cube);
            int random = Random.Range(1,3);
            
            cube.transform.position = new Vector3(20*i, 8, target.transform.position.z);
            
            if (random == 1){
                cube.AddComponent<DScript_level2>();
                cube.AddComponent<TextMeshPro>();
                 cube.GetComponent<DScript_level2>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<DScript_level2>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<DScript_level2>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<DScript_level2>().newPlayerBulletSpawn = newPlayerBulletSpawn;

                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "1";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 2){
                cube.AddComponent<SScript_level2>();
                cube.AddComponent<TextMeshPro>();
                 cube.GetComponent<SScript_level2>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<SScript_level2>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<SScript_level2>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<SScript_level2>().newPlayerBulletSpawn = newPlayerBulletSpawn;

                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "2";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_level2>();
                cube.AddComponent<TextMeshPro>();
                 cube.GetComponent<AScript_level2>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<AScript_level2>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<AScript_level2>().newBulletSpeed = newBulletSpeed;
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "3";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else{
                cube.AddComponent<WScript_level2>();
                cube.AddComponent<TextMeshPro>();
                 cube.GetComponent<WScript_level2>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<WScript_level2>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<WScript_level2>().newBulletSpeed = newBulletSpeed;
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
