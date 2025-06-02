using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public SystemSequence systemS;

    public void OnButtonClick(Button button)
    {
        TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();

        systemS.SelectNumber(text.text);
    }
}
