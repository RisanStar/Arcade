using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ItemCollect3D : MonoBehaviour
{
    public int fruitCount { get; private set; }
    [SerializeField] private TextMeshProUGUI fruitCounttxt; 

    [SerializeField] private FroggerMovement3D frogmove3D;
    [SerializeField] private GameObject counter;

    [SerializeField] private GameObject frog;

    public int scoreCount { get; private set; }
    private int scoreCalc;
    private int scoreMulti;
    [SerializeField] private TextMeshProUGUI scoreCountTxt;

    private Vector3 newSize;
    private Vector3 originalSize;

    private void Start()
    {
        counter.SetActive(false);
        fruitCount = 0;
        fruitCounttxt.text = "";

        scoreCount = 0;
        scoreCountTxt.text = "";

        newSize = new Vector3(.1f, .1f, .1f);
        originalSize = new Vector3(2, 2, 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            counter.SetActive(true); 

            Destroy(other.gameObject);

            fruitCount++;
            fruitCounttxt.text = " " + fruitCount;

            frog.transform.localScale += newSize;
        }
    }

    private void Update()
    {
        scoreCountTxt.text = "" + scoreCount;

        if (fruitCount > 5)
        {
            scoreMulti = 2;
            scoreCalc = 100 * fruitCount * scoreMulti;
        }
        else if (fruitCount > 10)
        {
            scoreMulti = 3;
            scoreCalc = 100 * fruitCount * scoreMulti;
        }
        else if (fruitCount > 15)
        {
            scoreMulti = 5;
            scoreCalc = 100 * fruitCount * scoreMulti;
        }
        else
        {
            scoreCalc = 100 * fruitCount;
        }

        if (Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.bKey.wasPressedThisFrame)
        {
            frog.transform.localScale = originalSize;
            scoreCount += scoreCalc;
            fruitCount = fruitCount - fruitCount;
            fruitCounttxt.text = " " + fruitCount;
        }

        if (frogmove3D.isDead == true)
        {
            counter.SetActive(false);
        }
    }
}
