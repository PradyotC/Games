using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreation_platform_level : MonoBehaviour
{
    public Transform target;
    BoxCollider cubeBox;
    // Start is called before the first frame update
    private double[] myNum =
    {
        1.125, 2.625, 4.125, 5.625, 7.125, 8.625, 12.375, 13.875, 15.375, 16.875, 18.375, 19.875, 22.875, 26.625, 29.625, 32.625, 35.062
    };

    void Start()
    {
        float prevPosition = target.transform.position.x;
        int i = 0;
        while (i < 0) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;

            cube.AddComponent<ObstacleCollision_level1>();

            // int random = Random.Range(5,20);
            int randomY = Random.Range(0, 2);
            // int obstacleChoice = Random.Range(0, 4);

            if (i!=0 && i!=3 && i!=6)
            {
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, target.transform.position.y + randomY * 2, target.transform.position.z);
            }
            else if (i==0)
            {
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, target.transform.position.y + 4f, target.transform.position.z);
                cube.AddComponent<ObstacleMovementUp_level1>();
            }
            else if (i==3)
            {
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, target.transform.position.y + 0.25f, target.transform.position.z);
                cube.AddComponent<ObstacleMovementRight_level1>();
            }
            else if (i==6)
            {
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, target.transform.position.y + 2f, target.transform.position.z);
                cube.AddComponent<ObstacleMovementSinusoidal_level1>();
            }

            if (i==5){
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, 3.1f, 0f);
                cube.transform.localScale = new Vector3(0.3f, 2.5f, 4f);
            }
            if (i==8){
                cube.transform.position = new Vector3((float)myNum[i] * 10 + 2f, 3.1f, 0f);
                cube.transform.localScale = new Vector3(0.3f, 2.5f, 4f);                
            }

            // Extra obstacles ideas: tan wave(impulse), movement at an angle, obstacle prefab with collider offsetted at the left, left right obstacle in the air

            //cube.transform.position = new Vector3((float)myNum[i]*10+2.3f, target.transform.position.y, target.transform.position.z);

            // prevPosition += random;
            // i+= Random.Range(2,5);
            ++i;
        }
        /*
        for(int i=0;i<myNum.Length;i++){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(cube.GetComponent<Collider>());
            //cube.AddComponent<ObstacleCollision>();
           //Destroy(cube.GetComponent<BoxCollider>());
            cubeBox = cube.GetComponent<BoxCollider>();
            cubeBox.isTrigger = true;

            cube.AddComponent<ObstacleCollision_level1>();
			
            //NoteMaker.transform.SetParent(cube);
            int random = Random.Range(5,20);
            int randomY = Random.Range(0, 2);
            
            cube.transform.position = new Vector3(prevPosition+random, target.transform.position.y + randomY*2, target.transform.position.z);
            //cube.transform.position = new Vector3((float)myNum[i]*10+2.3f, target.transform.position.y, target.transform.position.z);

            prevPosition += random;
        } */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
