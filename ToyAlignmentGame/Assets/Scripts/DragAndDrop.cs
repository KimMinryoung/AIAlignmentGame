using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Text.RegularExpressions;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int curOverlappedTarget;
    private Vector2 startPos;
    private Vector3 offset;
    private TargetTracker tracker;
    private Transform parentTF;

    void Start()
    {
        parentTF = transform.parent;
        startPos = parentTF.position;
        tracker = GameObject.Find("SceneManager").GetComponent<TargetTracker>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = parentTF.position;
        Vector3 startMousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        offset = parentTF.position - startMousePos;
    }

    void moveToCurPos(Vector3 curPos){
        curPos.x = Mathf.Clamp(curPos.x, DisplayManager.minX, DisplayManager.maxX);
        curPos.y = Mathf.Clamp(curPos.y, DisplayManager.minY, DisplayManager.maxY);
        curPos.z = parentTF.position.z;
        parentTF.position = curPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector3 curPos = mousePos + offset;
        moveToCurPos(curPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the sprite is over one of the drag target object
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector3 curPos = mousePos + offset;
        moveToCurPos(curPos);

        RaycastHit2D[] hits = Physics2D.RaycastAll(curPos, Vector2.zero, 0);
        
        bool overlapped = false;
        foreach(RaycastHit2D hit in hits){
            if (hit.collider != null && hit.collider.gameObject.tag == "DragTarget")
            {
                // Move the sprite onto the box(but if the object is on basket, don't move it)
                GameObject target = hit.collider.gameObject;
                Debug.Log(target.name);
                if(target.name=="Basket"){
                    overlapped = true;
                    tracker.UpdateObjectTarget(this.gameObject, null);
                    updateCurTargetValue(target.name);
                }
                else{
                    if(!tracker.IsTargetMapped(target)){
                        overlapped = true;
                        tracker.UpdateObjectTarget(this.gameObject, target);
                        updateCurTargetValue(target.name);
                        Vector3 targetPos = hit.collider.transform.position;
                        targetPos.z= parentTF.position.z;
                        parentTF.position = targetPos;
                    }else{
                    }
                }
            }
        }
        if(!overlapped){
                // If the sprite is not over any target, move it back to its starting position
                parentTF.position = new Vector3(startPos.x, startPos.y, parentTF.position.z);
        }
    }
    
    // Update the value of the object based on the target it is on
    private void updateCurTargetValue(string targetName)
    {
        if(targetName == "Basket"){
            curOverlappedTarget = 0;
        }
        else{
            var match = Regex.Match(targetName, @"\d+");
            int targetNum = 0;
            if (match.Success)
            {
                targetNum = int.Parse(match.Value);
            }
            else{
                Debug.Log("Overlap target's name can't be parsed");
                targetNum = -1;
            }
            curOverlappedTarget = targetNum;
        }
        Debug.Log(curOverlappedTarget);
    }
}