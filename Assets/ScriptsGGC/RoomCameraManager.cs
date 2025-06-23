using UnityEngine;
using System.Collections.Generic;

public class RoomCameraManager : MonoBehaviour
{
    public static RoomCameraManager Instance;

    [System.Serializable]
    public class RoomData
    {
        public string roomID;             // ID único de cada habitación
        public Camera roomCamera;         // Cámara asociada a esa habitación
    }

    [Header("Lista de habitaciones y sus cámaras")]
    public List<RoomData> rooms;

    private string currentRoomID = "";

    private void Awake()
    {
        // Aplicamos patrón Singleton básico
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Apagamos todas las cámaras al iniciar
        foreach (var room in rooms)
        {
            if (room.roomCamera != null)
                room.roomCamera.enabled = false;
        }

        // Activamos la primera cámara si hay al menos una
        if (rooms.Count > 0 && rooms[0].roomCamera != null)
        {
            currentRoomID = rooms[0].roomID;
            rooms[0].roomCamera.enabled = true;
        }
    }

    public void ChangeRoom(string newRoomID)
    {
        // Si ya estamos en la habitación destino, no hacemos nada
        if (newRoomID == currentRoomID)
        {
            Debug.Log($"[RoomCameraManager] Ya estás en la habitación {newRoomID}");
            return;
        }

        // Apagamos la cámara actual
        Camera currentCamera = GetCameraByRoomID(currentRoomID);
        if (currentCamera != null)
        {
            currentCamera.enabled = false;
        }

        // Encendemos la cámara del nuevo cuarto
        Camera newCamera = GetCameraByRoomID(newRoomID);
        if (newCamera != null)
        {
            newCamera.enabled = true;
            currentRoomID = newRoomID;
            Debug.Log($"[RoomCameraManager] Cámara cambiada a habitación: {newRoomID}");
        }
        else
        {
            Debug.LogWarning($"[RoomCameraManager] No se encontró una cámara para la habitación: {newRoomID}");
        }
    }

    private Camera GetCameraByRoomID(string id)
    {
        foreach (var room in rooms)
        {
            if (room.roomID == id)
                return room.roomCamera;
        }
        return null;
    }
}
