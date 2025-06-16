using UnityEngine;

public class RoomCameraTrigger2D : MonoBehaviour
{
    [Tooltip("Cámara asociada a este cuarto")]
    public Camera roomCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger 2D detectado con: " + other.name);

        // Verificamos si el objeto que entró al trigger es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado, cambiando cámara...");
            SetCameraActive();
        }
        else
        {
            Debug.Log("Objeto no válido: " + other.name);
        }
    }

    // Activa la cámara asignada a esta habitación y desactiva las demás
    private void SetCameraActive()
    {
        // Desactivamos todas las cámaras en la escena
        Camera[] allCameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in allCameras)
        {
            cam.enabled = false;
        }

        // Activamos la cámara correspondiente a este cuarto
        if (roomCamera != null)
        {
            roomCamera.enabled = true;
            Debug.Log("Cámara activada: " + roomCamera.name);
        }
        else
        {
            Debug.LogWarning("No se asignó una cámara en este RoomCameraTrigger.");
        }
    }
}
