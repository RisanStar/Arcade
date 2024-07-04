using UnityEngine;

public class Logs3D : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider Bcollider;

    [SerializeField] private LogSpawner3D spawner;

    [SerializeField] private Logs3D log;

    private void Awake()
    { 
        spawner = FindObjectOfType<LogSpawner3D>();
        log = FindObjectOfType<Logs3D>();
        Bcollider = log.GetComponent<BoxCollider>();
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
            speed = Random.Range(5f, 10f);
            speed = Mathf.RoundToInt(speed);
        }

        rb.velocity += speed * Time.deltaTime * Vector3.right;

    }
    
 
}
