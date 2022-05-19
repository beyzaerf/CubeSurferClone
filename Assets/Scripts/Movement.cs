using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rigidBody;
    private bool inCollision = false;
    private bool collected;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if(!inCollision)
            rigidBody.transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    private void OnCollisionEnter(Collision collision) // birbirlerine deðince stack up olacak ve yapýþacaklar.
    {
        
        if (collision.gameObject.tag == "Collectible")
        {
            collected = true;
            collision.transform.position = new Vector3(transform.position.x, collision.transform.position.y, transform.position.z);
            transform.position += Vector3.up;
            collision.gameObject.transform.parent = this.transform;

        }

        else if (collision.gameObject.tag == "Obstacle")
        {
            var collider1 = collision.gameObject.GetComponent<Collider>().transform;
            if(collider1.transform.position.y <= collision.transform.position.y) // if there isnt enough cubes to move through the obstacle 
            {
                inCollision = true;
                collider1.parent = null;
                Debug.Log("Level failed.");
            }
            else // if the cube is taller than the obstacle, leave the necessary cubes and continue 
            {
                
            }
        }
    }

}
