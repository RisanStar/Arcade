using TMPro;
using UnityEngine;

public class Cars : MonoBehaviour
{
    private float speed;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;

    [SerializeField] private GameObject car;
    private Vector3 carPos;
    public bool tooFar { get; private set; }

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        Left = GameObject.Find("LeftSpawner");
        Right = GameObject.Find("RightSpawner");
        spawner = FindAnyObjectByType<Spawner>();;
    }
    private void Start()
    {
        carPos = transform.position;
    }
    private void Update()
    {
        if (spawner.canSpawn)
        {
            speed = Random.Range(5f, 20f);
            speed = Mathf.RoundToInt(speed);
        }

        if (Right.transform.position.x == carPos.x)
        {
            rb.velocity += speed * Time.deltaTime * Vector2.left;
        }

        if (Left.transform.position.x == carPos.x)
        {
            rb.velocity += speed * Time.deltaTime * Vector2.right;
        }

    }
}
