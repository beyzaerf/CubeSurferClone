using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraFollow;
    [SerializeField] float height = 4.3f;
    [SerializeField] float horizontalPosition = 2.7f;

    void Update()
    {
        transform.position = new Vector3(horizontalPosition, height, cameraFollow.position.z - 7f);    
    }

}
