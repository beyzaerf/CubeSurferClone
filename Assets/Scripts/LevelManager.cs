using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int levelID;
    private int activeLevel;
    public GameObject[] levelPrefabs; //bunun içini nasýl dolduracaksýn?

    public int ActiveLevel { get => activeLevel; set => activeLevel = value; }

    private void Start()
    {
        PlayerPrefs.SetInt("LevelInfo", levelID);
        ActiveLevel = PlayerPrefs.GetInt("LevelInfo", 1);

    }

    public void SpawnLevel()
    {
        int i = 0;
        Instantiate(levelPrefabs[i], new Vector3(0,0,0), Quaternion.identity);
        i++;
    }
}
