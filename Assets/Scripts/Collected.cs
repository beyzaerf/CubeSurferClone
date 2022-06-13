using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    private PickUp pickUp;
    private void Start()
    {
        pickUp = ObjectManager.Instance.PlayerObject.GetComponent<PickUp>();
    }
    private void OnCollisionEnter(Collision collision) //Losing cubes from obstacles.
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            transform.parent = null;
            if (pickUp.transform.childCount <= 1)
            {
                GameManager.Instance.gameState = GameState.GameOver;
                Debug.Log(GameManager.Instance.gameState);
            }
        }
        else if (collision.gameObject.CompareTag("Multiplier")) // eðer multipliera vurursa 
        {
            pickUp.DiamondCount *= 2;
            transform.parent = null;
            collision.gameObject.tag = "Untagged";
            Debug.Log(pickUp.DiamondCount);
            if(pickUp.transform.childCount <= 1)
            {
                GameManager.Instance.gameState = GameState.GameWon;
                Debug.Log(GameManager.Instance.gameState);
            }
        }
    }
}
