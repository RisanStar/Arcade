using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    private float logCount = 0f;
    public float logTimer;
    public bool canSpawn { get; private set; }

    [SerializeField] private GameObject[] logs;
    private float randomLog;
    private int pickedLog;

    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        logTimer = 1.3f;

    }
    private void Update()
    {
        randomLog = Random.value;
        randomLog = Mathf.RoundToInt(randomLog);
        Debug.Log(randomLog);

        if (randomLog == 0)
        {
            pickedLog = 0;
        }
        if (randomLog == 1)
        {
            pickedLog = 1;
        }


        if (canSpawn)
        {
            Instantiate(logs[pickedLog], spawnPoint, Quaternion.identity);
        }

        {
            logCount -= 1f * Time.deltaTime;
            if (logCount <= 0f) { logCount = 0f; }
            if (logCount == 0f)
            {
                canSpawn = true;
                logCount += logTimer;
            }
            else
                canSpawn = false;

        }
    }
    }
