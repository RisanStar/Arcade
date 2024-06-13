using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Cars : MonoBehaviour
{
    private float speed;

    [SerializeField] private GameObject car;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FroggerMovement frogMove;

    private void Update()
    {
        speed = Random.Range(5f, 20f);
        rb.velocity +=  speed * Time.deltaTime * Vector2.left; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
           if (frogMove.isDead == true)
           {
               speed = 0f;
               rb.velocity += speed * Time.deltaTime * Vector2.left;
           }
        }
    }
}
