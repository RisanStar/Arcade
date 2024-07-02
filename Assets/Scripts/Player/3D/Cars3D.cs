using UnityEngine;

public class Cars3D : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider Bcollider;

    [SerializeField] private Spawner3D spawner;

    [SerializeField] private Cars3D car;

    private void Awake()
    { 
        spawner = FindObjectOfType<Spawner3D>();
        car = FindObjectOfType<Cars3D>();
        Bcollider = car.GetComponent<BoxCollider>();
    }
    private void Start()
    {
        Physics.IgnoreCollision(Bcollider, Bcollider);
    }
    private void Update()
    {
        // Debug.Log("Lifespan: " + lifeSpan);
        if (spawner.canSpawn)
        {
            speed = Random.Range(10f, 20f);
            speed = Mathf.RoundToInt(speed);
        }

        rb.velocity += speed * Time.deltaTime * Vector3.right;

    }
    
 
}
