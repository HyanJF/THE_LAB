using UnityEngine;

public class RoomCameraTrigger2D : MonoBehaviour
{
    [Tooltip("C�mara asociada a este cuarto")]
    public Camera roomCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger 2D detectado con: " + other.name);

        // Verificamos si el objeto que entr� al trigger es el jugador
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado, cambiando c�mara...");
            SetCameraActive();
        }
        else
        {
            Debug.Log("Objeto no v�lido: " + other.name);
        }
    }

    // Activa la c�mara asignada a esta habitaci�n y desactiva las dem�s
    private void SetCameraActive()
    {
        // Desactivamos todas las c�maras en la escena
        Camera[] allCameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in allCameras)
        {
            cam.enabled = false;
        }

        // Activamos la c�mara correspondiente a este cuarto
        if (roomCamera != null)
        {
            roomCamera.enabled = true;
            Debug.Log("C�mara activada: " + roomCamera.name);
        }
        else
        {
            Debug.LogWarning("No se asign� una c�mara en este RoomCameraTrigger.");
        }
    }
}
