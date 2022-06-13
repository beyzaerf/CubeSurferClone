using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int levelID;
    private int activeLevel;

    public int ActiveLevel { get => activeLevel; set => activeLevel = value; }

    private void Start()
    {
        PlayerPrefs.SetInt("LevelInfo", levelID);
        ActiveLevel = PlayerPrefs.GetInt("LevelInfo", 1);

    }
}
