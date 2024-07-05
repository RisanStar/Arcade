using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ItemCollect : MonoBehaviour
{
    private int fruitCount;
    [SerializeField] private TextMeshProUGUI fruitCountTxt;

    private void Start()
    {
        fruitCount = 0;
        fruitCountTxt.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            fruitCount++;
            fruitCountTxt.text = "" + fruitCount;
        }
    }
}
