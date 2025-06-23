using UnityEngine;
using System.Collections.Generic;

public class RoomCameraManager : MonoBehaviour
{
    public static RoomCameraManager Instance;

    [System.Serializable]
    public class RoomData
    {
        public string roomID;             // ID �nico de cada habitaci�n
        public Camera roomCamera;         // C�mara asociada a esa habitaci�n
    }

    [Header("Lista de habitaciones y sus c�maras")]
    public List<RoomData> rooms;

    private string currentRoomID = "";

    private void Awake()
    {
        // Aplicamos patr�n Singleton b�sico
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Apagamos todas las c�maras al iniciar
        foreach (var room in rooms)
        {
            if (room.roomCamera != null)
                room.roomCamera.enabled = false;
        }

        // Activamos la primera c�mara si hay al menos una
        if (rooms.Count > 0 && rooms[0].roomCamera != null)
        {
            currentRoomID = rooms[0].roomID;
            rooms[0].roomCamera.enabled = true;
        }
    }

    public void ChangeRoom(string newRoomID)
    {
        // Si ya estamos en la habitaci�n destino, no hacemos nada
        if (newRoomID == currentRoomID)
        {
            Debug.Log($"[RoomCameraManager] Ya est�s en la habitaci�n {newRoomID}");
            return;
        }

        // Apagamos la c�mara actual
        Camera currentCamera = GetCameraByRoomID(currentRoomID);
        if (currentCamera != null)
        {
            currentCamera.enabled = false;
        }

        // Encendemos la c�mara del nuevo cuarto
        Camera newCamera = GetCameraByRoomID(newRoomID);
        if (newCamera != null)
        {
            newCamera.enabled = true;
            currentRoomID = newRoomID;
            Debug.Log($"[RoomCameraManager] C�mara cambiada a habitaci�n: {newRoomID}");
        }
        else
        {
            Debug.LogWarning($"[RoomCameraManager] No se encontr� una c�mara para la habitaci�n: {newRoomID}");
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
