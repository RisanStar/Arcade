using UnityEngine;

public class Cars : MonoBehaviour
{
    private float speed;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;

    [SerializeField] private GameObject car;
    [SerializeField] private SpriteRenderer carRender;
    private Vector3 carPos;
    
    public bool tooFar { get; private set; }

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        Left = GameObject.Find("LeftSpawner");
        Right = GameObject.Find("RightSpawner");

        spawner = FindObjectOfType<Spawner>();
        
    }
    private void Start()
    {
        carPos = transform.position;
    }
    private void Update()
    {
        // Debug.Log("Lifespan: " + lifeSpan);
        if (spawner.canSpawn)
        {
            speed = Random.Range(10f, 20f);
            speed = Mathf.RoundToInt(speed);
        }

        if (Right.transform.position.x == carPos.x)
        {
            carRender.flipX = true;
            rb.velocity += speed * Time.deltaTime * Vector2.left;
        }

        if (Left.transform.position.x == carPos.x)
        {
            rb.velocity += speed * Time.deltaTime * Vector2.right;
        }
    }
    
 
}
