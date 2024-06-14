using UnityEngine;

public class Cars : MonoBehaviour
{
    private float speed;

    [SerializeField] private GameObject car;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FroggerMovement frogMove;

    [SerializeField] private Spawner spawner;
    private void Update()
    {
        if (spawner.canSpawn)
        {
            speed = Random.Range(5f, 20f);
        }
        Debug.Log("Speed now equals: " + speed);
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
