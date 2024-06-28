using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement3D : MonoBehaviour
{
    [SerializeField] GameObject frog;
    private Vector3 frogPosition;
    [SerializeField] private FroggerMovement3D frogerMovement;

    private void Update()
    {
        frogPosition = new Vector3(frog.transform.position.x + 5f, frog.transform.position.y + 5f, frog.transform.position.z + 5f);
        transform.position = Vector3.Lerp(transform.position, frogPosition, 1f * Time.deltaTime);

    }
}
