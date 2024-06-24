using UnityEngine;
using UnityEngine.UIElements;

public class LvlTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlVariant;
    [SerializeField] private GameObject berry;

    private Vector3 lvlSpawn;
    private Vector3 berrySpawn;

    private float randX;
    private float randZ;

    public float randomLvl { get; private set;}
    private void Awake()
    {
        randomLvl = Random.value;
        randomLvl = Mathf.RoundToInt(randomLvl);

        randX = Random.Range(-6f, 2f);
        randX = Mathf.RoundToInt(randX);

        randZ = Random.Range(2f, 7f);
        randZ = Mathf.RoundToInt(randZ);

        berrySpawn = new Vector3(randX, transform.position.y, randZ);
    }
    private void Start()
    {
        lvlSpawn = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        berrySpawn = new Vector3(randX, transform.position.y, transform.position.z + randZ);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            Debug.Log("Entered Trigger");
            Instantiate(berry, berrySpawn, Quaternion.identity);

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
