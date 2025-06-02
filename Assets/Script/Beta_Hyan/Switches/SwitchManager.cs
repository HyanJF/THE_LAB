using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public SwitchButton[] switches;
    public GameObject objectToDeactivate;

    public void CheakAllSwitches()
    {
        foreach (var sw in switches)
        {
            if (!sw.isActivate)
                return;
            
        }

        objectToDeactivate.SetActive(false);
    }

    public void ResetAllSwitches()
    {
        foreach (var sw in switches)
        {
            sw.ResetSwitch();
        }

        objectToDeactivate.SetActive(true);
    }
}
