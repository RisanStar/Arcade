using System.Collections.Generic;
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
    [SerializeField] private Animator animator;
    private Vector3 newPosition;

    private List<string> animationList = new List<string>
                                            {   "Attack",
                                                "Bounce",
                                                "Clicked",
                                                "Death",
                                                "Eat",
                                                "Fear",
                                                "Fly",
                                                "Hit",
                                                "Idle_A", "Idle_B", "Idle_C",
                                                "Jump",
                                                "Roll",
                                                "Run",
                                                "Sit",
                                                "Spin/Splash",
                                                "Swim",
                                                "Walk"
                                            };

    private void Start()
    {
        transform.position = transform.position;
        isDead = false;
        canMoveUp = false;
        canMoveDown = false;
    }

    private void Update()
    {
        newPosition.y = -.4f;

        if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow))
        {
            newPosition.z += 1f;
            transform.position = newPosition;
            canMoveUp = true;

        }

        else if (Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow))
        {

            newPosition.z -= 1f;
            transform.position = newPosition;
            canMoveDown = true;
        }

        else if (Input.GetKeyDown(leftA) || Input.GetKeyDown(leftArrow))
        {
            newPosition.x -= 1f;
            transform.position = newPosition;

        }

        else if (Input.GetKeyDown(rightD) || Input.GetKeyDown(rightArrow))
        {
            newPosition.x += 1f;
            transform.position = newPosition;

        }
        else
        {
            canMoveUp = false;
            canMoveDown = false;
        }

        if (transform.position.z < 0f)
        {
            newPosition.z += 1f;
            transform.position = newPosition;
        }

        if (transform.position.x > 4f)
        {
            newPosition.x -= 1f;
            transform.position = newPosition;
        }

        if (transform.position.x < -7f)
        {
            newPosition.x += 1f;
            transform.position = newPosition;
        }

        Animation();
        Die();
    }

    private void Animation()
    {
        if (TryGetComponent(out animator))
        {
            animator.Play("Idle_A");

            if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow) || Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow) || Input.GetKeyDown(leftA) || Input.GetKeyDown(leftArrow) || Input.GetKeyDown(rightD) || Input.GetKeyDown(rightArrow))
            {
                animator.Play("Bounce");
            }
        }
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
