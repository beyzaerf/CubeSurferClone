using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class Control : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X"), -2f, 2f), transform.position.y, transform.position.z);
        }
        
    }
    
}

#else

public class Control : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetTouch(0).position.x, -2f, 2f), transform.position.y + transform.position.z);
        }
    }
}
#endif