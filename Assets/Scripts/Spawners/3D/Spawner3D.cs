using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour
{
    private float carCount = 0f;
    public float carTimer;
    public bool canSpawn { get; private set; }

    [SerializeField] private GameObject[] cars;
    private Vector3 carSpawnPoint;
    private Vector3 otherSpawnPoint;

    private float randomCar;
    private int pickedCar;

    private void Start()
    {
        carSpawnPoint = new Vector3(transform.position.x, .2f, transform.position.z);
        otherSpawnPoint = new Vector3(transform.position.x, 1f, transform.position.z);
        carTimer = 3f;

    }
    private void Update()
    {
        randomCar = Random.Range(0 ,cars.Length);
        randomCar = Mathf.RoundToInt(randomCar);

        if (randomCar == 0)
        {
            pickedCar = 0;
        }
        else if (randomCar == 1)
        {
            pickedCar = 1;
        }
        else if(randomCar == 2)
        {
            pickedCar = 2;
        }
        else
        {
            pickedCar = 3;
        }


        if (canSpawn && randomCar == 0 || canSpawn && randomCar == 2)
        {
            Instantiate(cars[pickedCar], carSpawnPoint, Quaternion.identity);
        }

        if (canSpawn && randomCar == 1 || canSpawn && randomCar == 3)
        {
            Instantiate(cars[pickedCar], otherSpawnPoint, Quaternion.identity);
        }

        {
            carCount -= 1f * Time.deltaTime;
            if (carCount <= 0f) { carCount = 0f; }
            if (carCount == 0f)
            {
                canSpawn = true;
                carCount += carTimer;
            }
            else
                canSpawn = false;

        }
    }
}
