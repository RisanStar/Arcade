using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private Vector2 spawnPoint;
    [SerializeField] private float spawnRate;


    private IEnumerator Spawn()
    {
        Instantiate(car, spawnPoint, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
    }

    private void Update()
    {
        StartCoroutine(Spawn());
    }
}
