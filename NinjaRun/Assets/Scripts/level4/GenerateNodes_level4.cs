using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateNodes_level4 : MonoBehaviour
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
            int random = Random.Range(1,5);
            
            cube.transform.position = new Vector3(20*i, 8, target.transform.position.z);
            
            if (random == 1){
                cube.AddComponent<DScript_level4>();
                 cube.GetComponent<DScript_level4>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<DScript_level4>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<DScript_level4>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<DScript_level4>().newPlayerBulletSpawn = newPlayerBulletSpawn;

                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "1";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);

            }
            else if (random == 2){
                cube.AddComponent<SScript_level4>();
                 cube.GetComponent<SScript_level4>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<SScript_level4>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<SScript_level4>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<SScript_level4>().newPlayerBulletSpawn = newPlayerBulletSpawn;

                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "2";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else if (random == 3){
                cube.AddComponent<AScript_level4>();
                 cube.GetComponent<AScript_level4>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<AScript_level4>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<AScript_level4>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<AScript_level4>().newPlayerBulletSpawn = newPlayerBulletSpawn;

                cube.AddComponent<TextMeshPro>();
                TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
                TextDisplay.text = "3";
                TextDisplay.fontSize = 10;
                RectTransform placement = cube.GetComponent<RectTransform>();
                placement.sizeDelta = new Vector2(1f, 1f);
            }
            else{
                cube.AddComponent<WScript_level4>();
                 cube.GetComponent<WScript_level4>().newBulletPrefab = newBulletPrefab;
                cube.GetComponent<WScript_level4>().newBulletSpawn = newBulletSpawn;
                cube.GetComponent<WScript_level4>().newBulletSpeed = newBulletSpeed;
                cube.GetComponent<WScript_level4>().newPlayerBulletSpawn = newPlayerBulletSpawn;

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
