using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private static Buttons instance;    
    public static Buttons Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        ObjectManager.Instance.NextButton.gameObject.SetActive(false);
        ObjectManager.Instance.RetryButton.gameObject.SetActive(false);
    }
    public void OnPlayGame()
    {
        GameManager.Instance.GameState = GameState.GameRunning;
        ObjectManager.Instance.PlayButton.gameObject.SetActive(false);
    }
}
