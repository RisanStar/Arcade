using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float carCount = 0f;
    private float carTimer;
    private bool canSpawn;

    [SerializeField] private GameObject car;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private IEnumerator Spawn()
    {
        carTimer = Random.Range(1f, 2f);
        if (canSpawn) 
        {
            Instantiate(car, spawnPoint, Quaternion.identity);
            yield return new WaitForSeconds(carCount);
        }     
    }

    private void Update()
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

        StartCoroutine(Spawn());
    }
}
