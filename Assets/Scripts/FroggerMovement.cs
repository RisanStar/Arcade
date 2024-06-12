using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroggerMovement : MonoBehaviour
{
    private KeyCode upW = KeyCode.W;
    private KeyCode upArrow = KeyCode.UpArrow;

    private KeyCode downS = KeyCode.S;
    private KeyCode downArrow = KeyCode.DownArrow;

    private KeyCode leftA = KeyCode.A;
    private KeyCode leftArrow = KeyCode.LeftArrow;

    private KeyCode rightD = KeyCode.D;
    private KeyCode rightArrow = KeyCode.RightArrow;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 1); 
        }
        if (Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 1);
        }
    }
}
