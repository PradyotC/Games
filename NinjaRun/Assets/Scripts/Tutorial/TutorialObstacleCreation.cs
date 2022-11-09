using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacleCreation : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        float prevPosition = target.transform.position.x;
        
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.position = new Vector3(prevPosition+20, target.transform.position.y, target.transform.position.z);
        prevPosition += 20;
        
        
        GameObject cubeToDuck = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeToDuck.transform.position = new Vector3(prevPosition+20, target.transform.position.y+2, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}