using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3D : MonoBehaviour
{
    private float xAxis;
    private float yAxis;
    private float zAxis;

    private float randomXSpeed;
    private float randomYSpeed;
    private float randomZSpeed;

    private void Start()
    {
        randomXSpeed = Random.value;
        randomYSpeed = Random.value;
        randomZSpeed = Random.value;

        xAxis = 5f * Time.deltaTime * randomXSpeed;
        yAxis = 5f * Time.deltaTime * randomYSpeed;
        zAxis = 5f * Time.deltaTime * randomZSpeed;
    }
    private void Update()
    {
        transform.Rotate(xAxis, yAxis, zAxis);
    }
}
