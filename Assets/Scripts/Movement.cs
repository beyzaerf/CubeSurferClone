using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float speed;
    private Rigidbody rigidBody;
    private Transform playerObject;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
        playerObject = ObjectManager.Instance.PlayerObject;

    }
    private void FixedUpdate()
    {
        if (gameManager.gameState != GameState.GameRunning)
        {
            return;
        }
            rigidBody.transform.position += speed * Time.deltaTime * Vector3.forward;
    }
}
