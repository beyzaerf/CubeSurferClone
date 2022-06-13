using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR

//This script allows the user to play with the mouse or phone.

public class Control : MonoBehaviour
{
    private Vector3 playerPosition;
    GameManager gameManager;
    private Transform playerObject;

    private void Start()
    {
        gameManager = GameManager.Instance;
        playerObject = ObjectManager.Instance.PlayerObject;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (gameManager.gameState != GameState.GameRunning)
            {
                return;
            }
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
            if (gameManager.gameState != GameState.GameRunning)
            {
                return;
            }
            Touch touch = Input.GetTouch(0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetTouch(0).position.x, -2f, 2f), transform.position.y + transform.position.z);
        }
    }
}
#endif