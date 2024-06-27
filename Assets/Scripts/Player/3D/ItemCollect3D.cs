using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollect3D : MonoBehaviour
{
    private int fruitCount;
    [SerializeField] private TextMeshProUGUI TMPUGUI;

    private void Start()
    {
        fruitCount = 0;
        TMPUGUI.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            fruitCount++;
            TMPUGUI.text = "" + fruitCount;
        }
    }

    private void Update()
    {
        if(fruitCount == 10)
        {
            SceneManager.LoadScene("Secret");
        }
    }
}
