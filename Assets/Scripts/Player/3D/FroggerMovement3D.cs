using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FroggerMovement3D : MonoBehaviour
{
    public bool isDead { get; private set; }
    public bool canMoveUp { get; private set; }
    public bool canMoveDown { get; private set; }

    private readonly KeyCode upW = KeyCode.W;
    private readonly KeyCode upArrow = KeyCode.UpArrow;

    private readonly KeyCode downS = KeyCode.S;
    private readonly KeyCode downArrow = KeyCode.DownArrow;

    private readonly KeyCode leftA = KeyCode.A;
    private readonly KeyCode leftArrow = KeyCode.LeftArrow;

    private readonly KeyCode rightD = KeyCode.D;
    private readonly KeyCode rightArrow = KeyCode.RightArrow;


    [SerializeField] private GameObject frog;
    [SerializeField] private Animator animator;
    private Vector3 newPosition;

    private float randomInt;
    private int pickedIdle;

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

        if (transform.position.x > 0f)
        {
            newPosition.x -= 1f;
            transform.position = newPosition;
        }

        if (transform.position.x < -7f)
        {
            newPosition.x += 1f;
            transform.position = newPosition;
        }

        StartCoroutine(RNG());
        Animation();
        Die();
    }

    private IEnumerator RNG()
    {
        yield return new WaitForSeconds(5);
        randomInt = Random.Range(0f, 3f);
        randomInt = Mathf.RoundToInt(randomInt);
        if (randomInt == 0)
        {
            pickedIdle = 0;
        }
    }

    private void Animation()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(upW) || Input.GetKeyDown(upArrow) || Input.GetKeyDown(downS) || Input.GetKeyDown(downArrow) || Input.GetKeyDown(leftA) || Input.GetKeyDown(leftArrow) || Input.GetKeyDown(rightD) || Input.GetKeyDown(rightArrow))
            {
                animator.SetBool("Moving", true);
                animator.SetInteger("RandomIdle", pickedIdle);
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
