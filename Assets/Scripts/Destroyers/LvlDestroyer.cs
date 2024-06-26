using UnityEngine;

public class LvlDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject frog;

    [SerializeField] private FroggerMovement frogMove;

    private Vector3 destroyerNewPos;

    private void Update()
    {

        if (frogMove.canMoveUp == true)
        {
            destroyerNewPos.y += 1f;
            transform.position = destroyerNewPos;
        }

        if (frogMove.canMoveDown == true)
        {
            destroyerNewPos.y -= 1f;
            transform.position = destroyerNewPos;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LvlVari") || collision.CompareTag("Car")) 
        {
            Destroy(collision.gameObject);
        }
    }

}
