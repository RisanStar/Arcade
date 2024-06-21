using UnityEngine;
using UnityEngine.UIElements;

public class LvlTrigger3D : MonoBehaviour
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

        randX = Random.Range(-5f, 5f);
        randX = Mathf.RoundToInt(randX);

        randZ = Random.Range(5f, 10f);
        randZ = Mathf.RoundToInt(randZ);

        berrySpawn = new Vector3(randX, randZ, transform.position.z);
    }
    private void Start()
    {
        lvlSpawn = new Vector3(0, 0, transform.position.z + 30);
        berrySpawn = new Vector3(randX, 1, transform.position.z + randZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Frog"))
        {
            Debug.Log("Entered Trigger");
            Instantiate(berry, berrySpawn, Quaternion.identity);

            if (randomLvl == 0)
            {
                Instantiate(lvlVariant[0], lvlSpawn, Quaternion.identity);
                if (GameObject.Find("Level Variant(1)3D"))
                {
                    lvlVariant[0].SetActive(true);
                }
            }

            if (randomLvl == 1)
            {
                Instantiate(lvlVariant[1], lvlSpawn, Quaternion.identity);
                if (GameObject.Find("Level Variant(2)3D"))
                {
                    lvlVariant[1].SetActive(true);
                }
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
