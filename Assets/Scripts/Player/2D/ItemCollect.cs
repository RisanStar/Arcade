using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ItemCollect : MonoBehaviour
{
    private int berryCount;
    [SerializeField] private TextMeshProUGUI berryCountTxt;

    private void Start()
    {
        berryCount = 0;
        berryCountTxt.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Berry"))
        {
            Destroy(collision.gameObject);
            berryCount++;
            berryCountTxt.text = "" + berryCount;
        }
    }
}
