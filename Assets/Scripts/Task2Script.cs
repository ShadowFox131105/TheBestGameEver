using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2Script : MonoBehaviour
{
    [Range(0f, 1f)]
    public float value;

    public Transform firstCube;
    public Transform secondCube;

    public Material material1;
    public Material material2;

    public Material material3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(firstCube.transform.position, secondCube.transform.position, value);
        transform.localScale = Vector3.Lerp(firstCube.localScale, secondCube.localScale, value);
        material3.color = Color.Lerp(material1.color, material2.color, value);
    }
}
