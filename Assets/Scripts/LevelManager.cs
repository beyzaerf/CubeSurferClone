using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int levelID;
    private int activeLevel;
    public GameObject[] levelPrefabs;
    private static LevelManager instance;

    public int ActiveLevel { get => activeLevel; set => activeLevel = value; }
    public static LevelManager Instance { get => instance; set => instance = value; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        levelID = PlayerPrefs.GetInt("LevelInfo", 0);
        Instantiate(levelPrefabs[levelID]); //spawns the level prefab here

    }
    public void SetLevel()
    {
        levelID++;
        PlayerPrefs.SetInt("LevelInfo", levelID);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
