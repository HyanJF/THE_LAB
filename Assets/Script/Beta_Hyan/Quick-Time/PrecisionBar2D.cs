using UnityEngine;
using UnityEngine.UI;

public class PrecisionBar2D : MonoBehaviour
{
    [Header("Elementos UI")]
    public RectTransform movingBar;
    public RectTransform targetBar;
    public RectTransform leftLimit;
    public RectTransform rightLimit;
    public Button stopButton;

    [Header("Configuracion")]
    public float speed = 300f;
    public float successMargin = 20f;

    private bool isMoving = true;
    private bool goingRight = true;

    private void Start()
    {
        stopButton.onClick.AddListener(StopBar);
        ResetBar();
    }

    private void Update()
    {
        if (!isMoving) return;

        float moveAmount = speed * Time.deltaTime;
        if (goingRight)
        {
            movingBar.anchoredPosition += Vector2.right * moveAmount;

            if (movingBar.anchoredPosition.x >= rightLimit.anchoredPosition.x)
                goingRight = false;
        }
        else
        {
            movingBar.anchoredPosition += Vector2.left * moveAmount;

            if (movingBar.anchoredPosition.x <= leftLimit.anchoredPosition.x)
                goingRight = true;
        }
    }

    public void StopBar()
    {
        isMoving = false;

        float barX = movingBar.anchoredPosition.x;
        float targetX = targetBar.anchoredPosition.x;

        if (Mathf.Abs(barX - targetX) <= successMargin)
        {
            Debug.Log("Exito");
            targetBar.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Fallo");
            targetBar.GetComponent<Image>().color = Color.red;
            ResetBar();
        }
    }

    public void ResetBar()
    {
        isMoving = true;
        goingRight = true;
        movingBar.anchoredPosition = leftLimit.anchoredPosition;
        targetBar.GetComponent<Image>().color = Color.white;
    }
}
