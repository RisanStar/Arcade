using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FroggerMovement : MonoBehaviour
{
    public bool isDead { get; private set; }
    private bool canDie;
    public bool canMoveUp { get; private set; }
    public bool canMoveDown { get; private set; }

    [SerializeField] private GameObject frog;

    private Vector2 newPosition;

    private enum MovementState { idle, moving }

    [SerializeField] private Logs[] logs;

    private void Start()
    {
        frog.transform.position = frog.transform.position;
        isDead = false;
        canMoveUp = false;
        canMoveDown = false;

    }

    private void Update()
    {
        logs = FindObjectsOfType<Logs>(); 

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newPosition.y += 1f;
            frog.transform.position = newPosition;
            canMoveUp = true;

        }

        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {

            newPosition.y -= 1f;
            frog.transform.position = newPosition;
            canMoveDown = true;
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newPosition.x -= 1f;
            frog.transform.position = newPosition;

        }

        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newPosition.x += 1f;
            frog.transform.position = newPosition;

        }
        else
        {
            canMoveUp = false;
            canMoveDown = false;
        }

        if (frog.transform.position.y < 0f)
        {
            newPosition.y += 1f;
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

        if (collision.CompareTag("Log"))
        {
            canDie = false;
        }
        else
        {
            canDie = true;
        }

        if(canDie == true)
        {
            if (collision.CompareTag("Water"))
            {
                isDead = true;
            }
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
