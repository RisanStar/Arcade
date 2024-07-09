using UnityEngine;

public class Logs : MonoBehaviour
{
    private float speed = 1f;

    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;

    [SerializeField] private GameObject log;
    [SerializeField] private SpriteRenderer logRender;
    private Vector3 logPos;
    
    public bool tooFar { get; private set; }

    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        Left = GameObject.Find("LeftSpawner");
        Right = GameObject.Find("RightSpawner");
        
    }
    private void Start()
    {
        logPos = transform.position;
    }
    private void Update()
    {
        // Debug.Log("Lifespan: " + lifeSpan);

        if (Right.transform.position.x == logPos.x)
        {
            logRender.flipX = true;
            rb.velocity += speed * .005f * Vector2.left;
        }

        if (Left.transform.position.x == logPos.x)
        {
            rb.velocity += speed * .005f * Vector2.right;
        }
    }
}
