using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform charTransform;
    private GameObject lastCollected = null;
    
        private void Start()
    {
        charTransform = transform.GetChild(0);
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

        }

        else if (collision.gameObject.CompareTag("Obstacle")) //Losing cubes from obstacle
        {
            //do
            //{
            //    if (transform.childCount <= 1)
            //    {
            //        GameManager.gameState = GameManager.GameState.GAMEOVER;
            //        break;
            //    }
            //    if (transform.GetChild(1) == true)
            //        transform.GetChild(1).parent = null;
            //} while (GameManager.gameState != GameManager.GameState.GAMEOVER);


            //if (transform.GetChild(1).position.y + transform.parent.position.y <= collision.transform.position.y) //If the cube is taller than the obstacle 
            //{
            //    /* 
            //     * When the gameState is gameover the game should automatically stop, so we should check the gamestate in the movement class.
            //     * if it is not gameover, it should move -> movement class 
            //     */
            //    GameManager.gameState = GameManager.GameState.GAMEOVER; 
            //}
            //else

            //if (transform.childCount > 1)

                transform.GetChild(1).parent = null;
        }
        else if (collision.gameObject.CompareTag("Multiplier"))
        {
            transform.GetChild(1).parent = null;
        }

        else if (collision.gameObject.CompareTag("Diamond")) //Picking up diamonds
        {
            if (GameManager.pointEvent != null)
            {
                GameManager.pointEvent(1);
                Destroy(collision.gameObject);
            }
        }
    }
}
