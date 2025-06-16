using UnityEngine;
using UnityEngine.UI;

public class HealthDropDK : MonoBehaviour
{
    public Image healthBar;
    public PlayerMovementDK player;
    public float dmg = 0.01f;

    void Update()
    {
        if (!player.objectPlaced)
        {
            healthBar.fillAmount += dmg * Time.deltaTime;
        }
    }
}
