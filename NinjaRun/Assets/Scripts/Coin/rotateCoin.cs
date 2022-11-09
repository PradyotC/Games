using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoin : MonoBehaviour
{
    // Start is called before the first frame update

    private int rotateSpeed;
    void Start()
    {
        rotateSpeed = 1; //declare coin rotate speed here
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
