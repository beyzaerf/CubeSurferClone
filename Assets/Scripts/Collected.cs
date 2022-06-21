using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collected : MonoBehaviour
{
    private ObjectManager objectManager;
    private GameManager gameManager;
    private PickUp pickUp;
    private Transform player;
    private void Start()
    {
        pickUp = ObjectManager.Instance.PlayerObject.GetComponent<PickUp>();
        objectManager = ObjectManager.Instance;
        gameManager = GameManager.Instance;
        player = ObjectManager.Instance.PlayerObject;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Multiplier")) // eðer multipliera vurursa 
        {
            transform.parent = null;
            collision.gameObject.tag = "Untagged";
            collision.isTrigger = false;
            pickUp.DiamondCount *= 2;
            objectManager.ScoreText.text = pickUp.DiamondCount.ToString();
            if (pickUp.transform.childCount <= 1)
            {
                player.GetChild(0).GetComponent<Rigidbody>().DORotate(new Vector3(0, 180, 0), 0.5f); //rotates the player
                objectManager.Animator.Play("Silly Dancing"); //dance animation plays
                gameManager.GameState = GameState.GameWon;
                gameManager.GameWin(); //next button appears
            }
        }
    }
    private void OnCollisionEnter(Collision collision) //Losing cubes from obstacles.
    {
       
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            transform.parent = null;
            if (pickUp.transform.childCount <= 1)
            {
                player.DOMoveZ(player.position.z - 1, 0.5f); //player falls 
                objectManager.Animator.Play("mixamo_com"); //death animation plays
                gameManager.GameFail(); //retry button appears 
                gameManager.GameState = GameState.GameOver;
            }
        }
        
    }
}
