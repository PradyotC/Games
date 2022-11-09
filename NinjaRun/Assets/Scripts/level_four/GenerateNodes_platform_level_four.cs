using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GenerateNodes_platform_level_four : MonoBehaviour
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
        1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 21.0, 22.0, 23.0, 24.0, 25.0, 26.0, 27.0, 28.0, 29.0, 30.0, 31.0, 32.0, 33.0
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
                cube.AddComponent<DScript_platform_level_four>();
                cubemeshRenderer.material = matE;
            }
            else if (random == 2){
                cube.AddComponent<SScript_platform_level_four>();
                cubemeshRenderer.material = matW;
            }
            else if (random == 3){
                cube.AddComponent<AScript_platform_level_four>();
                cubemeshRenderer.material = matQ;
            }
           
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

