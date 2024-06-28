using UnityEngine;
using UnityEngine.UIElements;

public class LvlTrigger3D : MonoBehaviour
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

    private void Start()
    {
        lvlSpawn = new Vector3(0, 0, transform.position.z + 30);

        randomLvl = Random.value;
        randomLvl = Mathf.RoundToInt(randomLvl);

        randomFruit = Random.Range(0f, fruits.Length);
        randomFruit = Mathf.RoundToInt(randomFruit);

        randX = Random.Range(-3f, 1f);
        randX = Mathf.RoundToInt(randX);

        randZ = Random.Range(5f, 10f);
        randZ = Mathf.RoundToInt(randZ);

        fruitSpawn = new Vector3(randX, 1, transform.position.z + randZ);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            Debug.Log("Entered Trigger");
            Instantiate(fruits[pickedFruit], fruitSpawn, Quaternion.identity);

            if (randomLvl == 0)
            {
                Instantiate(lvlVariant[0], lvlSpawn, Quaternion.identity);
            }

            if (randomLvl == 1)
            {
                Instantiate(lvlVariant[1], lvlSpawn, Quaternion.identity);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            Destroy(gameObject);
        }
    }

}
