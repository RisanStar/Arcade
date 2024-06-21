using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3D : MonoBehaviour
{
    private float carCount = 0f;
    public float carTimer;
    public bool canSpawn { get; private set; }

    [SerializeField] private GameObject[] cars;
    private Vector3 spawnPoint;

    private float randomCar;
    private int pickedCar;

    private void Start()
    {
        spawnPoint = new Vector3(transform.position.x, 1, transform.position.z);
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


        if (canSpawn)
        {
            Instantiate(cars[pickedCar], spawnPoint, Quaternion.identity);
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
