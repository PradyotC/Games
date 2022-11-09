using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMove : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x+5f, transform.position.y, 0);
    }
}
