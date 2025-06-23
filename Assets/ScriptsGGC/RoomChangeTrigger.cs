using UnityEngine;

public class RoomChangeTringger : MonoBehaviour
{
    [Tooltip("ID de la habitación destino")]
    public string destinationRoomID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"[RoomChangeTrigger] Jugador tocó trigger. Cambiando a habitación: {destinationRoomID}");
            RoomCameraManager.Instance.ChangeRoom(destinationRoomID);
        }
    }
}