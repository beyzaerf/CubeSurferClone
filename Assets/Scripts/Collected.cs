using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                GameManager.Instance.GameFail();
                GameManager.Instance.GameState = GameState.GameOver;
            }
        }
        else if (collision.gameObject.CompareTag("Multiplier")) // eðer multipliera vurursa 
        {
            pickUp.DiamondCount *= 2;
            transform.parent = null;
            collision.gameObject.tag = "Untagged";
            if(pickUp.transform.childCount <= 1)
            {
                GameManager.Instance.GameState = GameState.GameWon;
                GameManager.Instance.GameWin();
            }
        }
    }
}
