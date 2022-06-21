using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows the user to play with the mouse or phone.
public class Control : MonoBehaviour
{
    Rigidbody rb;
    Vector3 firstPosition;
    Vector3 lastPosition;
    Vector3 difference;
    [SerializeField] float speed;
    [SerializeField] Camera ortho;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2, 2), transform.position.y, transform.position.z);
        firstPosition = Vector3.Lerp(firstPosition, ortho.ScreenToWorldPoint(Input.mousePosition), 0.3f);
        if (Input.GetMouseButtonDown(0))
        {
            firstPosition = ortho.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            difference = Vector3.zero;
        }
        if (Input.GetMouseButton(0))
        {
            lastPosition = ortho.ScreenToWorldPoint(Input.mousePosition);
            difference = lastPosition - firstPosition;
            difference *= 70;

            if (GameManager.Instance.GameState != GameState.GameRunning)
            {
                return;
            }

        }
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.GameState != GameState.GameRunning)
        {
            rb.velocity = Vector3.zero;
            return;
        }
            
        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(difference.x, 0, speed), 0.3f);
        
    }
}