using UnityEngine;
using UnityEngine.UIElements;

public class LvlTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlVariant;
    [SerializeField] private GameObject[] fruits;

    private Vector3 lvlSpawn;
    private Vector3 fruitSpawn;

    private float randX;
    private float randZ;

    public float randomLvl { get; private set;}
    private float randomFruit;
    private int pickedFruit;
    private void Awake()
    {
        randomLvl = Random.value;
        randomLvl = Mathf.RoundToInt(randomLvl);

        randomFruit = Random.Range(0f, fruits.Length - 1);
        randomFruit = Mathf.RoundToInt(randomFruit);

        randX = Random.Range(-6f, 2f);
        randX = Mathf.RoundToInt(randX);

        randZ = Random.Range(2f, 7f);
        randZ = Mathf.RoundToInt(randZ);

        fruitSpawn = new Vector3(randX, transform.position.y, randZ);
    }
    private void Start()
    {
        lvlSpawn = new Vector3(transform.position.x, transform.position.y + 7.3f, transform.position.z);
        fruitSpawn = new Vector3(randX, transform.position.y, transform.position.z + randZ);
    }

    private void Update()
    {
        if (randomFruit == 0)
        {
            pickedFruit = 0;
        }

        if (randomFruit == 1)
        {
            pickedFruit = 1;
        }

        if (randomFruit == 2)
        {
            pickedFruit = 2;
        }

        if (randomFruit == 3)
        {
            pickedFruit = 3;
        }

        if (pickedFruit == 4)
        {
            pickedFruit = 4;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            Debug.Log("Entered Trigger");
            Instantiate(fruits[pickedFruit], fruitSpawn, Quaternion.identity);

            if (randomLvl == 0)
            {
                Instantiate(lvlVariant[0], lvlSpawn, Quaternion.identity);
                if (GameObject.Find("Level Variant(1)"))
                {
                    lvlVariant[0].SetActive(true);
                }
            }

            if (randomLvl == 1)
            {
                Instantiate(lvlVariant[1], lvlSpawn, Quaternion.identity);
                if (GameObject.Find("Level Variant(2)"))
                {
                    lvlVariant[1].SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            Destroy(gameObject);
        }
    }

}
