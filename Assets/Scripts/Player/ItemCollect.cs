using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollect : MonoBehaviour
{
    private int berryCount;

    private void Start()
    {
        berryCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Berry"))
        {
            Destroy(collision.gameObject);
            berryCount++;
        }
    }

    private void Update()
    {
        if(berryCount == 10)
        {
            SceneManager.LoadScene("Lvl 3D");
        }
    }
}
