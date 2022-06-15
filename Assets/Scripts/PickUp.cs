using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private FollowCamera followCamera;
    private Transform charTransform;
    private int cubeCount = 1;
    private GameObject lastCollected = null;
    private int diamondCount = 0;

    public int DiamondCount { get => diamondCount; set => diamondCount = value; }

    private void Start()
    {
        charTransform = transform.GetChild(0);
        followCamera = ObjectManager.Instance.Camera.GetComponent<FollowCamera>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collectible") && collision.gameObject != lastCollected) //Picking up cubes
        {
            if (lastCollected == null) 
                collision.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            else
                collision.transform.position = new Vector3(transform.position.x, lastCollected.transform.position.y + 1, transform.position.z);
            charTransform.position = new Vector3(transform.position.x, collision.transform.position.y + 0.5f, transform.position.z);
            collision.transform.parent = transform;
            lastCollected = collision.gameObject;
            collision.transform.tag = "Untagged";
            cubeCount++;
            if(cubeCount > 5)
            {
                followCamera.CameraZoomOut();
            }


        }
        else if (collision.gameObject.CompareTag("Obstacle")) //Losing cubes from obstacle
        {
            cubeCount--;
            transform.GetChild(1).parent = null;
            if (transform.childCount > 5)
                followCamera.CameraZoomIn();

        }
       
        else if (collision.gameObject.CompareTag("Diamond")) //Picking up diamonds
        {
            diamondCount++;
            ObjectManager.Instance.ScoreText.text = diamondCount.ToString();
            Destroy(collision.gameObject);
        }
        
    }
}
