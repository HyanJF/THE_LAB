using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectDropDK : MonoBehaviour
{
    public PlayerObjectInteractionDK playerRef;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerRef.canDropObject = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRef.canDropObject = false;
    }
}
