using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPickUpDK : MonoBehaviour
{
    public PlayerObjectInteractionDK playerRef;

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerRef.canMoveObject = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRef.canMoveObject = false;
    }
}
