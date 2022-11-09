using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialNodes : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(60, 3, 2);
        
        cube.AddComponent<DScript>();
        cube.AddComponent<TextMeshPro>();
        TextMeshPro TextDisplay = cube.GetComponent<TextMeshPro>();
        TextDisplay.text = "E";
        TextDisplay.fontSize = 10;
        RectTransform placement = cube.GetComponent<RectTransform>();
        placement.sizeDelta = new Vector2(1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
