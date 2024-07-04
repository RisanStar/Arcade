using UnityEngine;

public class LogSpawner3D : MonoBehaviour
{
    private float logCount = 0f;
    public float logTimer;
    public bool canSpawn { get; private set; }

    [SerializeField] private GameObject[] logs;
    private Vector3 logSpawnPoint;

    private float randomLog;
    private int pickedLog;

    private void Start()
    {
        logSpawnPoint = new Vector3(transform.position.x, -1.7f, transform.position.z);
        logTimer = 1f;

    }
    private void Update()
    {
        randomLog = Random.Range(0 ,logs.Length - 1);
        randomLog = Mathf.RoundToInt(randomLog);

        if (randomLog == 0)
        {
            pickedLog = 0;
        }
        else 
        {
            pickedLog = 1;
        }


        if (canSpawn && randomLog == 0 || canSpawn && randomLog == 2)
        {
            Instantiate(logs[pickedLog], logSpawnPoint, Quaternion.identity);
        }

        if (canSpawn && randomLog == 1 || canSpawn && randomLog == 3)
        {
            Instantiate(logs[pickedLog], logSpawnPoint, Quaternion.identity);
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
