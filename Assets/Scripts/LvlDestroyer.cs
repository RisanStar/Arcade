using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject frog;

    private void Update()
    {
        transform.position = frog.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LvlVari"))
        {
            Destroy(collision.gameObject);
        }
    }
}
