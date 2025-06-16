using UnityEngine;

public class SlowingZoneDK : MonoBehaviour
{
    public PlayerMovementDK player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            Debug.Log("Player inside Slowing Zone");
            player.speed = 2.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player left Slowing Zone");
            player.speed = 5;
        }
    }
}
