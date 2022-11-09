using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreation_lvl3 : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        float prevPosition = target.transform.position.x;
        for(int i=1;i<60;i++){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(cube.GetComponent<Collider>());
            //cube.AddComponent<ObstacleCollision>();
			
            //NoteMaker.transform.SetParent(cube);
            int random = Random.Range(5,20);
            int randomY = Random.Range(0, 2);
            
            cube.transform.position = new Vector3(prevPosition+random, target.transform.position.y + randomY*2, target.transform.position.z);
            prevPosition += random;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
