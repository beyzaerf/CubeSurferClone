using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button replayButton;
    LevelManager levelManager;
    private static Buttons instance;

    public Button NextButton { get => nextButton; set => nextButton = value; }
    public static Buttons Instance { get => instance; set => instance = value; }
    public Button ReplayButton { get => replayButton; set => replayButton = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        NextButton.gameObject.SetActive(false);
        ReplayButton.gameObject.SetActive(false);
    }
    public void OnPlayGame()
    {
        GameManager.Instance.gameState = GameState.GameRunning;
        playButton.gameObject.SetActive(false);
    }
    
    public void OnNextButton() 
    {
        levelManager.ActiveLevel++;
    }
    public void OnReplayButton()
    {
        levelManager.SpawnLevel();
    }

}
