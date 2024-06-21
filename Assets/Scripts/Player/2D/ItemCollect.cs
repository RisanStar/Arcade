using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollect : MonoBehaviour
{
    private int berryCount;
    [SerializeField] private TextMeshProUGUI TMPUGUI;

    private void Start()
    {
        berryCount = 0;
        TMPUGUI.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Berry"))
        {
            Destroy(collision.gameObject);
            berryCount++;
            TMPUGUI.text = "" + berryCount;
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
