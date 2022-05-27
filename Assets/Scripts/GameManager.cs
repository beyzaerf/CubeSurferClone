using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameState gameState = GameState.GAMESTART;
    public static GameManager instance;
    public int score = 0;
    public static Action<int> pointEvent;

    private void Start()
    {
        pointEvent += addPoint;
    }

    //private void Update()
    //{
    //    switch (gameState)
    //    {
    //        case GameState.GAMERUNNING:
    //            break;
    //        case GameState.GAMESTART:
    //            break;
    //        case GameState.GAMEOVER:
    //            break;

    //    }
    //}

    // Singleton 
    private void Awake()
    {
        if (instance is null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    public void addPoint(int i)
    {
        score += 1;
    }

    public enum GameState
    {
        GAMESTART,
        GAMEOVER,
        GAMERUNNING
    }
}
