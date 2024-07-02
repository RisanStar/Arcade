using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemCollect3D : MonoBehaviour
{
    public int fruitCount { get; private set; }
    [SerializeField] private TextMeshProUGUI TMPUGUI; 
    [SerializeField] private FroggerMovement3D frogmove3D;
    [SerializeField] private GameObject counter;

    private void Start()
    {
        counter.SetActive(false);
        fruitCount = 0;
        TMPUGUI.text = "";

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            counter.SetActive(true); 
            Destroy(other.gameObject);
            fruitCount++;
            TMPUGUI.text = " " + fruitCount;
        }
    }

    private void Update()
    {
        if (frogmove3D.isDead == true)
        {
            counter.SetActive(false);
        }

        if(fruitCount == 10)
        {
            SceneManager.LoadScene("Secret");
        }
    }
}
