using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float carCount = 0f;
    public float carTimer;
    public bool canSpawn { get; private set; }

    [SerializeField] private GameObject car;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        carTimer = 1.5f;

    }
    private void Update()
    {
        if (canSpawn)
        {
            Instantiate(car, spawnPoint, Quaternion.identity);
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
