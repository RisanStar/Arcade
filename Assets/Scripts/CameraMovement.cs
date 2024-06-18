using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject frog;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, frog.transform.position.y, transform.position.z); 
    }
}
