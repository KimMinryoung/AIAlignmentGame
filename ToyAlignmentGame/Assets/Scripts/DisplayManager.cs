using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public static float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate the minimum and maximum allowed x and y values
        minX = -Camera.main.orthographicSize * Camera.main.aspect + transform.lossyScale.x / 2;
        maxX = Camera.main.orthographicSize * Camera.main.aspect - transform.lossyScale.x / 2;
        minY = -Camera.main.orthographicSize + transform.lossyScale.y / 2;
        maxY = Camera.main.orthographicSize - transform.lossyScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
