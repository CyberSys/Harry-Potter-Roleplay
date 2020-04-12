using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWarning : MonoBehaviour
{
    public Text text;

    public void Start()
    {
        DisplayText("", 0);
    }

    public void DisplayText(string message, float displayTime)
    {
        text.text = message;
        StartCoroutine(HideText(displayTime));
    }

    IEnumerator HideText(float displayTime)
    {
        yield return new WaitForSeconds(displayTime);
        text.text = "";
    }
}
