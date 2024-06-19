using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Cars cars;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))   
        {
          Destroy(collision.gameObject);
        }
    }
}