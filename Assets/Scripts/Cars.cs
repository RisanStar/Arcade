using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    private float speed;

    [SerializeField] private GameObject car;
    [SerializeField] private Rigidbody2D rb;


    private void Update()
    {
        speed = Random.Range(5f, 10f);
        rb.velocity +=  Vector2.left * speed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
