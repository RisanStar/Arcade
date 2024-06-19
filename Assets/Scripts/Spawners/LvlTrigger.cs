using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlVariant;

    private Vector3 lvlSpawn;

    private float randomLvl;
    private void Awake()
    {
        randomLvl = Random.value;
        randomLvl = Mathf.RoundToInt(randomLvl);
    }
    private void Start()
    {
        lvlSpawn = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
    }
    private void Update()
    {
        randomLvl = Random.value;
        randomLvl = Mathf.RoundToInt(randomLvl);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            Debug.Log("Entered Trigger");
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
