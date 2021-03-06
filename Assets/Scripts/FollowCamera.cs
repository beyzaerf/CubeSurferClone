using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 playerPosition;
    public Transform cameraFollow;
    private Vector3 offset;
    private void Start()
    {
        offset = new Vector3(2, 4.5f, -8);
        playerTransform = ObjectManager.Instance.PlayerObject;
    }
    void FixedUpdate()
    {
        playerPosition = playerTransform.position;
        transform.position = Vector3.Lerp(transform.position, playerPosition + offset, 0.1f);
    }

    public void CameraZoomOut()
    {
        offset.y += 0.5f;
        offset.z -= 0.3f;

    }
    public void CameraZoomIn()
    {
        offset.y -= 0.5f;
        offset.z += 0.3f;
    }
    
}
