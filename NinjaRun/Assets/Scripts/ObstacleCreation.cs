using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreation : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        float prevPosition = target.transform.position.x;
        for(int i=1;i<30;i++){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // DestroyImmediate(cube.GetComponent<Collider>());
            //cube.AddComponent<ObstacleCollision>();
			
            //NoteMaker.transform.SetParent(cube);
            int random = Random.Range(5,20);
            
            cube.transform.position = new Vector3(prevPosition+random, target.transform.position.y, target.transform.position.z);
            prevPosition += random;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
