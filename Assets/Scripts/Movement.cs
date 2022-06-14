using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rigidBody;
    private Transform playerObject;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerObject = ObjectManager.Instance.PlayerObject;

    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.GameState != GameState.GameRunning)
        {
            return;
        }
            rigidBody.transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
