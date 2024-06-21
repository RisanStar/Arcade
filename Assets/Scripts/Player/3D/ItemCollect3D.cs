using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollect3D : MonoBehaviour
{
    private int berryCount;
    [SerializeField] private TextMeshProUGUI TMPUGUI;

    private void Start()
    {
        berryCount = 0;
        TMPUGUI.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Berry"))
        {
            Destroy(other.gameObject);
            berryCount++;
            TMPUGUI.text = "" + berryCount;
        }
    }

    private void Update()
    {
        if(berryCount == 10)
        {
            SceneManager.LoadScene("Secret");
        }
    }
}
