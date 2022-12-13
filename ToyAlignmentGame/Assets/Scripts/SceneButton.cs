using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public Texture2D buttonImage;

    void OnGUI()
    {
        if (GUI.Button(new Rect(30, 30, 50, 50), buttonImage))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
