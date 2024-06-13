using UnityEngine;
using UnityEngine.SceneManagement;

public class FroggerMovement : MonoBehaviour
{
    public bool isDead { get; private set; }
    private KeyCode upW = KeyCode.W;
    private KeyCode upArrow = KeyCode.UpArrow;

    private KeyCode downS = KeyCode.S;
    private KeyCode downArrow = KeyCode.DownArrow;

    private KeyCode leftA = KeyCode.A;
    private KeyCode leftArrow = KeyCode.LeftArrow;

    private KeyCode rightD = KeyCode.D;
    private KeyCode rightArrow = KeyCode.RightArrow;


    [SerializeField] private GameObject frog;
    private Vector2 newPosition;

    private enum MovementState { idle, moving }


    private void Start()
    {
        frog.transform.position = frog.transform.position;
        isDead = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow))
        {
            newPosition.y += 1f;
            frog.transform.position = newPosition;

        }

        else if (Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow))
        {

            newPosition.y -= 1f;
            frog.transform.position = newPosition;
        }

        else if (Input.GetKeyDown(leftA) || Input.GetKeyDown(leftArrow))
        {
            newPosition.x -= 1f;
            frog.transform.position = newPosition;

        }

        else if (Input.GetKeyDown(rightD) || Input.GetKeyDown(rightArrow))
        {
            newPosition.x += 1f;
            frog.transform.position = newPosition;

        }

        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            isDead = true;
        }
    }

    private void Die()
    {
        if (isDead)
        {
            Destroy(frog);
            SceneManager.LoadScene("MainGame");
        }
    }
}
