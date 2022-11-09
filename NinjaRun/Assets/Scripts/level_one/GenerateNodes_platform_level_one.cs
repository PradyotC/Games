using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GenerateNodes_platform_level_one : MonoBehaviour
{
    public Transform target;
    public GameObject newBulletPrefab;
    public Transform newBulletSpawn;
    BoxCollider cubeBox;
    public GameObject coin;
    public Material matQ,matW,matE,matR;
    public Transform newPlayerBulletSpawn;
    public static int cnt = 0;
    public float newBulletSpeed = 10.0f;
    private double[] myNum =
    {
         0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24, 24.75, 26.25, 27, 27.75, 29.25, 30, 30.75, 32.25, 1.125, 2.625, 4.125, 5.625, 7.125, 8.625, 12.375, 13.875, 15.375, 16.875, 18.375, 19.875, 22.875, 26.625, 29.625, 32.625, 35.062
        //0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 9.75, 10.5, 12, 13.5, 15, 16.5, 18, 19.5, 21, 21.75, 22.5, 23.25, 24
        //0.75, 2.25, 3.75, 4.687, 6, 7.5, 9, 10.5, 12, 13.5,  16.5, 18
    };
	
    void Start()
    {
        Array.Sort(myNum);
        float[] maze_ind = {-1,1};

        for (int i = 0; i < myNum.Length; i+=3)
        {
            if(myNum[i] > 18){
                continue;
            }

            // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // cubeBox = cube.GetComponent<BoxCollider>();
            
            ////////////////////////////For player rhythm collector/////////////////////////////
            int randomIndex = UnityEngine.Random.Range(0, 2);
            ////////////////////////////////////////////////////////////////////////

            GameObject cube = Instantiate(coin, new Vector3((float)myNum[i] * 10 + 1.8f, 3, maze_ind[randomIndex]), Quaternion.Euler(90f, 0f, 90f));
            cube.transform.localScale = new Vector3(1f,0.05f,1f);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;
            MeshRenderer cubemeshRenderer = cube.GetComponent<MeshRenderer>();
            int random = UnityEngine.Random.Range(1,3);

            
            if (random == 1){
                cube.AddComponent<DScript_platform_level_one>();
                cubemeshRenderer.material = matE;
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_one>();
                cubemeshRenderer.material = matW;
            }
            else if (random == 3){
                cube.AddComponent<AScript_platform_level_one>();
                cubemeshRenderer.material = matQ;
            }
            else{
                cube.AddComponent<WScript_platform_level_one>();
                cubemeshRenderer.material = matR;
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
