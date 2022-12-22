using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            // This will create a new instance of the prefab at the origin (0, 0, 0)
            GameObject newObject = Instantiate(prefab);

            // You can then use the transform of the new object to change its position, rotation, and scale
            newObject.transform.position = new Vector3(i, i, -0.5f);
            newObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            newObject.transform.localScale = Vector3.one;
            newObject.GetComponent<PrintText>().UpdateText("옵션 "+i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
