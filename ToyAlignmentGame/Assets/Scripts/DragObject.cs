using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {
    private Vector2 startPos;
    private Vector2 currentPos;
    private Vector2 offset;
    private float originalPosZ;

    void OnMouseDown() {
        startPos = Input.mousePosition;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(startPos.x, startPos.y, 0));
        originalPosZ = transform.position.z;
    }

    void OnMouseDrag() {
        currentPos = Input.mousePosition;
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(new Vector3(currentPos.x, currentPos.y, 0));

        // Calculate the minimum and maximum allowed x and y values
        float minX = -Camera.main.orthographicSize * Camera.main.aspect + transform.lossyScale.x / 2;
        float maxX = Camera.main.orthographicSize * Camera.main.aspect - transform.lossyScale.x / 2;
        float minY = -Camera.main.orthographicSize + transform.lossyScale.y / 2;
        float maxY = Camera.main.orthographicSize - transform.lossyScale.y / 2;

        // Clamp the object's position to the screen bounds
        curPosition.x = Mathf.Clamp(curPosition.x + offset.x, minX, maxX);
        curPosition.y = Mathf.Clamp(curPosition.y + offset.y, minY, maxY);
        curPosition.z = originalPosZ;

        transform.position = curPosition;
    }
}
