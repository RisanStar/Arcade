using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement3D : MonoBehaviour
{
    [SerializeField] GameObject frog;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, frog.transform.position.z + 3.5f); 
    }
}
