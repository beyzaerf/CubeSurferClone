using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraFollow;
    [SerializeField] float height = 5;
    [SerializeField] float horizontalPosition = 4;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(horizontalPosition, height, cameraFollow.position.z - 6f);    
    }

}
