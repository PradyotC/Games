using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 7f;
    private void Update(){
        transform.position-=transform.right * Time.deltaTime*speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Here");
        Destroy(gameObject);
    }
}
