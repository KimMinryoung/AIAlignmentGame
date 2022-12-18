using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 startPos;
    private Vector3 offset;

    void Start()
    {
        startPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        Vector3 startMousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = transform.position - startMousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector3 curPos = mousePos + offset;
        curPos.x = Mathf.Clamp(curPos.x, DisplayManager.minX, DisplayManager.maxX);
        curPos.y = Mathf.Clamp(curPos.y, DisplayManager.minY, DisplayManager.maxY);
        curPos.z = transform.position.z;
        transform.position = curPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the sprite is over one of the drag target object
        // Vector2 mousePos = eventData.position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector3 curPos = mousePos + offset;
        curPos.x = Mathf.Clamp(curPos.x, DisplayManager.minX, DisplayManager.maxX);
        curPos.y = Mathf.Clamp(curPos.y, DisplayManager.minY, DisplayManager.maxY);
        curPos.z = transform.position.z;
        transform.position = curPos;

        //RaycastHit2D[] hits = Physics2D.RaycastAll(curPos, curPos - new Vector3(startPos.x, startPos.y, curPos.z));
        RaycastHit2D[] hits = Physics2D.RaycastAll(curPos, Vector2.zero);
        
        bool overlapped = false;
        foreach(RaycastHit2D hit in hits){
            if (hit.collider != null && hit.collider.gameObject.tag == "DragTarget")
            {
                Debug.Log("collided");
                overlapped = true;
                // Assign a value to the sprite
                // You can do this by adding a script to the sprite game object and setting a public variable
                // Or you can use the GetComponent method to access a script on the sprite game object and set a variable directly
                // Example: GetComponent<SpriteScript>().value = 10;

                // Move the sprite onto the box(but if the object is on basket, don't move it)
                if(hit.collider.gameObject.name != "Basket"){
                    Debug.Log(hit.collider.gameObject.name);
                    Vector3 targetPos = hit.collider.transform.position;
                    targetPos.z= transform.position.z;
                    transform.position = targetPos;
                }
            }
        }
        if(!overlapped){
                // If the sprite is not over any target, move it back to its starting position
                transform.position = new Vector3(startPos.x, startPos.y, transform.position.z);
        }
    }
}