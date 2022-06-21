using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private ObjectManager objectManager;
    private static GameManager instance;
    public Action GameWin;
    public Action GameFail;
    [SerializeField] private GameObject playButton;
    public static GameManager Instance { get => instance; set => instance = value; }
    public GameState GameState { get => gameState; set => gameState = value; }
    public bool GameExecuted { get => gameExecuted; set => gameExecuted = value; }

    private bool gameExecuted;
    // Singleton 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        objectManager = ObjectManager.Instance;
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
        objectManager.NextButton.SetActive(true);
    }
    private void GameFailFunction()
    {
        objectManager.RetryButton.SetActive(true);
    }
    public void GameStartFunction()
    {
        gameState = GameState.GameRunning;
        playButton.SetActive(false);
        GameExecuted = true;
    }
}

public enum GameState
{
    GameStart,
    GameOver,
    GameRunning,
    GameWon
}
