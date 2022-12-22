using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintText : MonoBehaviour
{
    public TMP_Text textMeshPro; // Reference to the TextProMesh component
    string textToPrint; // The text to print
    Color textColor; // The color of the text
    void Start()
    {
        textColor = Color.black;
        textMeshPro.text = textToPrint;
        textMeshPro.color = textColor;
    }

    public void UpdateText(string text){
        Debug.Log(text);
        textToPrint = text;
        textMeshPro.text = text;
    }
}