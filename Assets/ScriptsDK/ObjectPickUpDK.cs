using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPickUpDK : MonoBehaviour
{
    public PlayerMovementDK abc;

    private void OnTriggerStay2D(Collider2D collision)
    {
        abc.canMoveObject = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        abc.canMoveObject = false;
    }
}
