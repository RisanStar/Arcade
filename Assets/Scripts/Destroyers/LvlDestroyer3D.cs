using UnityEngine;

public class LvlDestroyer3D : MonoBehaviour
{
    [SerializeField] private FroggerMovement3D frogMove;

    private Vector3 destroyerNewPos;

    private void Update()
    {
        destroyerNewPos.y = 1;

        if (frogMove.canMoveUp == true)
        {
            destroyerNewPos.z += 1;
            transform.position = destroyerNewPos;
        }
        else
        {
            destroyerNewPos = transform.position;
        }

        if (frogMove.canMoveDown == true)
        {
            destroyerNewPos.z -= 1;
            transform.position = destroyerNewPos;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LvlVari")) 
        {
            Destroy(other.gameObject);
        }
    }

}
