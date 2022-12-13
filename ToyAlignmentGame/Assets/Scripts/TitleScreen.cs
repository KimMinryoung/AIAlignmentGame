using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("test");
    }
    
    void OnGUI()
    {
        //GUI.color = Color.red;
        GUI.color = new Color(0, 0, 0);
        //written at the position (10, 10) with a width of 100 pixels and a height of 20 pixels
        GUI.Label(new Rect(10, 10, 100, 20), "Hello, World!");

        

        GUI.color = Color.green;
        GUI.Label(new Rect(10, 30, 100, 20), "This is a second line of text.");

        GUI.color = Color.blue;
        GUI.Label(new Rect(10, 50, 100, 20), "This is a third line of text.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
