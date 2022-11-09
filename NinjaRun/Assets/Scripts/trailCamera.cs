using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trailCamera : MonoBehaviour
{
    public Transform target;
    public float trailDistance = 5.0f;
    public float heightOffset = 3.0f;
    public float cameraDelay = 0.02f;
    public float speed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        // camera is up
        if (SceneManager.GetActiveScene().buildIndex == 8) {
            transform.position=new Vector3(target.transform.position.x-10, transform.position.y,transform.position.z);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 11) {
            transform.position=new Vector3(target.transform.position.x-10, transform.position.y,transform.position.z);
        }
        // camera is side-ways
        else {
            transform.position=new Vector3(target.transform.position.x+6, transform.position.y,transform.position.z);
        }
   
    }
}
