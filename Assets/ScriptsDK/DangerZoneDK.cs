using UnityEngine;

public class DangerZoneDK : MonoBehaviour
{
    public HealthDropDK healthBarRef;
    public float zoneDmg = 0.05f;

    private bool playerInside = false;

    private void Update()
    {
        if (playerInside)
        {
            healthBarRef.healthBar.fillAmount += zoneDmg * Time.deltaTime;
            Debug.Log("Room took damage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            playerInside = true;
            Debug.Log("Player inside Danger Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player left Danger Zone");
        }
    }
}
