using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UI;

public class SystemSequence : MonoBehaviour
{
    public Button[] sequence;
    public TextMeshProUGUI[] textButtons;
    public Stack<float> numbers_sequence = new Stack<float>();
    void Start()
    {
        List<float> numbers = new List<float>();

        for (int i = 1; i < 11; i++)
        {
            numbers.Add((float)i);
        }

        numbers = numbers.OrderBy(n => Random.Range(0f, 1f)).ToList();

        for (int i = 0; i < textButtons.Length && i < numbers.Count; i++)
        {
            textButtons[i].text = numbers[i].ToString();   
        }
    }

    public void SelectNumber(string number)
    {
        if(float.TryParse(number, out float number_f))
        {
            float next = numbers_sequence.Count == 0 ? 1f : numbers_sequence.Peek() + 1f;
        
            if(Mathf.Approximately(number_f, next))
            {
                numbers_sequence.Push(number_f);
                Debug.Log("Valor agregado a la pila: " + number_f);
            }
            else
            {
                numbers_sequence.Clear();
                Debug.Log("Numero invalido");

                if(Mathf.Approximately(number_f, 1f))
                {
                    numbers_sequence.Push(number_f);
                    Debug.Log("Se reinicia con 1");
                }
            }
        }
    }

    void Update()
    {
        
    }
}
