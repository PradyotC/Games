using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementUp_level_ayan : MonoBehaviour
{
    public Vector3 startPosition;

    private float frequency = 3f;
    private float magnitude = 4f;
    private float offset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPosition + transform.up * Mathf.Cos(Time.time * frequency + offset) * magnitude;
    }
}
