using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject replayButton;
    LevelManager levelManager;
    private void Start()
    {
        nextButton.SetActive(false);
        replayButton.SetActive(false);
    }
    public void onPlayGame()
    {
        GameManager.Instance.gameState = GameState.GameRunning;
        playButton.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.GameWon)
        {
            nextButton.SetActive(true);
        }
        else if(GameManager.Instance.gameState == GameState.GameOver)
        {
            replayButton.SetActive(true);
        }
    }
    
    public void onNextButton() 
    {
        levelManager.ActiveLevel++;
    }
    public void onReplayButton()
    {
        
    }

}
