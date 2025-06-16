using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    public bool isActivate = false;
    public Button button;
    private SwitchManager manager;

    private void Start()
    {
        manager = FindFirstObjectByType<SwitchManager>();
        button.onClick.AddListener(OnPress);
        UpdateVisual();
    }

    void OnPress()
    {
        if(!isActivate)
        {
            isActivate = true;
            button.interactable = false;

            UpdateVisual();
            manager.CheakAllSwitches();
        }
    }

    void UpdateVisual()
    {
        var colors = button.colors;
        colors.normalColor = isActivate ? Color.green : Color.red;
        button.colors = colors;
    }

    public void ResetSwitch()
    {
        isActivate = false;
        button.interactable = true;
        UpdateVisual();
    }
}
