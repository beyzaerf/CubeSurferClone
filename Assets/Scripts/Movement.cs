using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rigidBody;
    private bool inCollision = false;
    private Transform charTransform;
    private GameObject lastCollected = null;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        charTransform = transform.GetChild(0);
        
    }

    private void Update()
    {
        if(!inCollision)
            rigidBody.transform.position += speed * Time.deltaTime * Vector3.forward;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible") && collision.gameObject != lastCollected)
        {
            if (lastCollected == null)
                collision.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            else
                collision.transform.position = new Vector3(transform.position.x, lastCollected.transform.position.y + 1, transform.position.z);
            
            charTransform.position = new Vector3(transform.position.x, collision.transform.position.y + 0.5f, transform.position.z);
            collision.gameObject.transform.parent = this.transform;
            lastCollected = collision.gameObject;

        }
        
        else if (collision.gameObject.tag == "Obstacle")
        {
            //var lastCubeCollider = collision.gameObject.GetComponent<Collider>().transform;
            inCollision = true;
            //if (Mathf.Abs(lastCubeCollider.position.y - collision.transform.position.y) < 0.1f) // if there isnt enough cubes to move through the obstacle 
            /*
            foreach (Transform child in transform)
            {
               if (child.CompareTag("Collectible") && collision.transform.gameObject == child)
                    child.parent = null;
            }
            */
                Debug.Log("Level failed.");
           
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            GameManager.instance.addPoint();
            Destroy(collision.gameObject);
            //Debug.Log(GameManager.instance.score);
        }
    }

}
