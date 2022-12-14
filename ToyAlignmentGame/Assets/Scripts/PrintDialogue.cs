using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintDialogue : MonoBehaviour
{
    public TMP_Text textMeshPro; // Reference to the TextProMesh component
    string textToPrint; // The text to print
    Color textColor; // The color of the text
    void Start()
    {
        textToPrint = "대사 테스트\n아아아";
        textColor = Color.black;
        textMeshPro.text = textToPrint;
        textMeshPro.color = textColor;
    }

    void Update()
    {
        
    }
}
