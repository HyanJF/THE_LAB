using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadTask : MonoBehaviour
{
    public Text cardCode;

    public Text inputCode;

    public int codeLength = 5;

    public float codeResetTimeInSeconds = 0.5f;

    private bool isResetting = false;

    private void Start()
    {
        inputCode.text = string.Empty;
        GenerateCode();
    }

    public void GenerateCode()
    {
        string code = string.Empty;

        for (int i = 0; i < codeLength; i++)
        {
            code += Random.Range(1, 10);
        }

        cardCode.text = code;
        
    }

    public void ButtonClick(int number)
    {
        if (isResetting) { return; }

        inputCode.text += number;

        if (inputCode.text == cardCode.text)
        {
            inputCode.text = " TA BIEN WEY";
            StartCoroutine(ResetCode());
        }
        else if (inputCode.text.Length == codeLength)
        {
            inputCode.text = " TA MAL WEY";
            StartCoroutine(ResetCode());
            GenerateCode();
        }
    }

    private IEnumerator ResetCode()
    {
        isResetting = true;

        yield return new WaitForSeconds(codeResetTimeInSeconds);

        inputCode.text = string.Empty;
        isResetting = false;

    }
}
