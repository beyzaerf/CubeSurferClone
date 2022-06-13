using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector3 playerPosition;
    public Transform cameraFollow;

    void FixedUpdate()
    {
        playerPosition = new Vector3(cameraFollow.position.x +2f, 6f, cameraFollow.position.z - 7f);
        transform.position = Vector3.Lerp(transform.position, playerPosition, 0.1f);
    }

}
