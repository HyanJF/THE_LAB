using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectDropDK : MonoBehaviour
{
    public PlayerMovementDK abc;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        abc.canDropObject = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        abc.canDropObject = false;
    }
}
