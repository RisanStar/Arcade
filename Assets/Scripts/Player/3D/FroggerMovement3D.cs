using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FroggerMovement3D : MonoBehaviour
{
    public bool isDead { get; private set; }
    public bool canMoveUp { get; private set; }
    public bool canMoveDown { get; private set; }

    private KeyCode upW = KeyCode.W;
    private KeyCode upArrow = KeyCode.UpArrow;

    private KeyCode downS = KeyCode.S;
    private KeyCode downArrow = KeyCode.DownArrow;

    private KeyCode leftA = KeyCode.A;
    private KeyCode leftArrow = KeyCode.LeftArrow;

    private KeyCode rightD = KeyCode.D;
    private KeyCode rightArrow = KeyCode.RightArrow;


    [SerializeField] private GameObject frog;
    private Vector3 newPosition;
    private enum MovementState { idle, moving }


    private void Start()
    {
        transform.position = transform.position;
        isDead = false;
        canMoveUp = false;
        canMoveDown = false;
    }

    private void Update()
    {
        newPosition.y = 1f;

        if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow))
        {
            newPosition.z += 2f;
            transform.position = newPosition;
            canMoveUp = true;

        }

        else if (Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow))
        {

            newPosition.z -= 2f;
            transform.position = newPosition;
            canMoveDown = true;
        }

        else if (Input.GetKeyDown(leftA) || Input.GetKeyDown(leftArrow))
        {
            newPosition.x -= 2f;
            transform.position = newPosition;

        }

        else if (Input.GetKeyDown(rightD) || Input.GetKeyDown(rightArrow))
        {
            newPosition.x += 2f;
            transform.position = newPosition;

        }
        else
        {
            canMoveUp = false;
            canMoveDown = false;
        }

        if (transform.position.z < 0f)
        {
            newPosition.z += 2f;
            transform.position = newPosition;
        }

        if (transform.position.x > 4f)
        {
            newPosition.x -= 2f;
            transform.position = newPosition;
        }

        if (transform.position.x < -7f)
        {
            newPosition.x += 2f;
            transform.position = newPosition;
        }

        Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
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
