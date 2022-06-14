using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState gameState;
    private static GameManager instance;
    public Action GameWin;
    public Action GameFail;
    
    public static GameManager Instance { get => instance; set => instance = value; }
    public GameState GameState { get => gameState; set => gameState = value; }

    // Singleton 
    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
    }
    public void NextLevel()
    {
        LevelManager.Instance.SetLevel();
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {
        GameWin += GameWinFunction;
        GameFail += GameFailFunction;
    }
    private void GameWinFunction()
    {
        ObjectManager.Instance.NextButton.SetActive(true);
    }
    private void GameFailFunction()
    {
        ObjectManager.Instance.RetryButton.SetActive(true);
    }
}

public enum GameState
{
    GameStart,
    GameOver,
    GameRunning,
    GameWon
}
