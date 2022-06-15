using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collected : MonoBehaviour
{
    private PickUp pickUp;
    private void Start()
    {
        pickUp = ObjectManager.Instance.PlayerObject.GetComponent<PickUp>();
    }
    private void OnCollisionEnter(Collision collision) //Losing cubes from obstacles.
    {
        Transform player = ObjectManager.Instance.PlayerObject;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.transform.GetComponent<BoxCollider>().enabled = false;
            transform.parent = null;
            if (pickUp.transform.childCount <= 1)
            {
                player.DOMoveZ(player.position.z - 1, 0.5f); //player falls 
                ObjectManager.Instance.Animator.Play("mixamo_com"); //death animation plays
                GameManager.Instance.GameFail(); //retry button appears 
                GameManager.Instance.GameState = GameState.GameOver;
            }
        }
        else if (collision.gameObject.CompareTag("Multiplier")) // eðer multipliera vurursa 
        {
            pickUp.DiamondCount *= 2;
            ObjectManager.Instance.ScoreText.text = pickUp.DiamondCount.ToString();
            transform.parent = null;
            collision.gameObject.tag = "Untagged";
            if(pickUp.transform.childCount <= 1)
            {
                player.GetChild(0).GetComponent<Rigidbody>().DORotate(new Vector3(0, 180, 0), 0.5f); //rotates the player
                ObjectManager.Instance.Animator.Play("Silly Dancing"); //dance animation plays
                GameManager.Instance.GameState = GameState.GameWon; //next button appears
                GameManager.Instance.GameWin();
            }
        }
    }
}
