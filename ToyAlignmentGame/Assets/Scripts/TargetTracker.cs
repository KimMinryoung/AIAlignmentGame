using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    // Dictionary to store the mapping of objects to their target game objects
    private Dictionary<GameObject, GameObject> objectTargets;

    void Start()
    {
        objectTargets = new Dictionary<GameObject, GameObject>();
    }

    public bool IsTargetMapped(GameObject target)
    {
        return objectTargets.ContainsValue(target);
    }
    // Method to get the target of a given object
    public GameObject GetObjectTarget(GameObject obj)
    {
        if (objectTargets.ContainsKey(obj))
        {
            return objectTargets[obj];
        }
        return null;
    }

    // Method to update the mapping of objects to their targets
    public void UpdateObjectTarget(GameObject obj, GameObject target)
    {
        // If the object is already in the dictionary, remove it
        if (objectTargets.ContainsKey(obj))
            objectTargets.Remove(obj);

        // Add the updated mapping to the dictionary (if there is valid target)
        if(target)
            objectTargets.Add(obj, target);
    }
}