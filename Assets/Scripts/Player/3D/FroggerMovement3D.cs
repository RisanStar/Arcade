using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FroggerMovement3D : MonoBehaviour
{
    public bool isDead { get; private set; }
    public bool canMoveUp { get; private set; }
    public bool canMoveDown { get; private set; }
    private bool cantMove;

    private bool onRoad;

    [SerializeField] private PlayerControls playerControls;
    [SerializeField] private InputAction playerMovement;
    [SerializeField] private InputAction playerUIClick;
    [SerializeField] private InputAction playerUINavi;
    [SerializeField] private InputAction playerExchange;
    [SerializeField] private InputAction playerContinue;

    [SerializeField] private Rigidbody frog;
    [SerializeField] private Animator animator;
    private Vector3 newPosition;

    [SerializeField] private ItemCollect3D itemCollect3D;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject cntrlScreen;


    private int lastFruitCount;
    private int lastScore;
    [SerializeField] private TextMeshProUGUI lastFruitTxt;
    [SerializeField] private TextMeshProUGUI lastScoreTxt;

    [SerializeField] private Button firstSelected;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerMovement = playerControls.Player.Move;
        playerMovement.Enable();

        playerContinue = playerControls.Player.Continue;
        playerControls.Enable();

        playerExchange = playerControls.Player.Exchange;
        playerExchange.Enable();

        playerUIClick = playerControls.UI.Click;
        playerUIClick.Enable();
        playerUIClick.performed += Click;

        playerUINavi = playerControls.UI.Navigate;
        playerUINavi.Enable();
        playerUINavi.performed += Navigation;
        
        newPosition = playerMovement.ReadValue<Vector3>();
    }
    private void OnDisable()
    {
        playerMovement.Disable(); 
        playerUIClick.Disable();
        playerUINavi.Disable();
        playerExchange.Disable();
        playerContinue.Disable();
   
    }
    private void Start()
    {
        isDead = false;
        canMoveUp = false;
        canMoveDown = false;
        cantMove = true;

        deathScreen.SetActive(false);
        cntrlScreen.SetActive(true);

        playerUIClick.Disable();

        playerContinue.Enable();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!isDead && !cantMove)
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
            newPosition.y = -.55f;
        }
        
        if (onRoad == false) 
        {
            newPosition.y = -.35f;
        }

        if (Keyboard.current.tabKey.wasPressedThisFrame || Keyboard.current.digit1Key.wasPressedThisFrame || Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            cantMove = false;
            playerContinue.Disable();
            cntrlScreen.SetActive(false);
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

        if (other.CompareTag("OOB"))
        {
            newPosition.z += 1f;
            transform.position = newPosition;
        }
    }

    private void Die()
    {
        if (isDead)
        {
            playerUIClick.Enable();
            playerExchange.Disable();

            lastFruitCount = itemCollect3D.fruitCount;
            lastFruitTxt.text = "" + lastFruitCount;

            lastScore = itemCollect3D.scoreCount;
            lastScoreTxt.text = "" + lastScore;

            deathScreen.SetActive(true);
            animator.SetBool("isDead", true);

            Cursor.lockState = CursorLockMode.None;
            

        }
    }

    private void Navigation(InputAction.CallbackContext context)
    {
        firstSelected.Select();
        Debug.Log("Moving");
    }

    private void Click(InputAction.CallbackContext context)
    {
        Debug.Log("clicking");
        SceneManager.LoadScene("Lvl 3D");
    }
}
