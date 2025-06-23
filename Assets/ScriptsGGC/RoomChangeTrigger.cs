using UnityEngine;

public class RoomChangeTringger : MonoBehaviour
{
    [Tooltip("ID de la habitaci�n destino")]
    public string destinationRoomID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"[RoomChangeTrigger] Jugador toc� trigger. Cambiando a habitaci�n: {destinationRoomID}");
            RoomCameraManager.Instance.ChangeRoom(destinationRoomID);
        }
    }
}