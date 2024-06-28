using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FroggerMovement3D : MonoBehaviour
{
    public bool isDead { get; private set; }
    public bool canMoveUp { get; private set; }
    public bool canMoveDown { get; private set; }
    private bool onRoad;

    [SerializeField] private InputAction playerMovement;

    [SerializeField] private GameObject frog;
    [SerializeField] private Animator animator;
    private Vector3 newPosition;

    private float randomInt;
    private int pickedIdle;

    private void OnEnable()
    {
        playerMovement.Enable();
        newPosition = playerMovement.ReadValue<Vector3>();
    }
    private void OnDisable()
    {
        playerMovement.Disable(); 
    }
    private void Start()
    {
        isDead = false;
        canMoveUp = false;
        canMoveDown = false;
    }

    private void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            newPosition.z += 1f;
            transform.position = newPosition;
            canMoveUp = true;
        }

        else if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame)
        {

            newPosition.z -= 1f;
            transform.position = newPosition;
            canMoveDown = true;
        }

        else if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            newPosition.x -= 1f;
            transform.position = newPosition;

        }

        else if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            newPosition.x += 1f;
            transform.position = newPosition;

        }
        else
        {
            canMoveUp = false;
            canMoveDown = false;
        }

        if (newPosition.z < 0f)
        {
            newPosition.z += 1f;
            transform.position = newPosition;
        }

        if (newPosition.x > 2f)
        {
            newPosition.x -= 1f;
            transform.position = newPosition;
        }

        if (newPosition.x < -7f)
        {
            newPosition.x += 1f;
            transform.position = newPosition;
        }

        if (onRoad == true)
        {
            newPosition.y = -.6f;
        }
        else
        {
            newPosition.y = -.35f;
        }

        Animation();
        Die();
    }

    private void Animation()
    {
        if (animator != null)
        {
            if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame)
            {
                animator.SetBool("Moving", true);
                animator.SetBool("isLanding", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isDead = true;
        }

        if (other.CompareTag("Road"))
        {
            onRoad = true;
        }

        if (other.CompareTag("Street"))
        {
            onRoad = false;
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
