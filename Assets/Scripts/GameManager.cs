using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    private static GameManager instance;

    public static GameManager Instance { get => instance; set => instance = value; }

    // Singleton 
    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
        }
       
    }
}
public enum GameState
{
    GameStart,
    GameOver,
    GameRunning,
    GameWon
}
