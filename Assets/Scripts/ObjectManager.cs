using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager instance;
    [SerializeField] private Transform playerObject;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject retryButton;

    public static ObjectManager Instance { get => instance; set => instance = value; }
    public Transform PlayerObject { get => playerObject; set => playerObject = value; }
    public GameObject NextButton { get => nextButton; set => nextButton = value; }
    public GameObject RetryButton { get => retryButton; set => retryButton = value; }
    public GameObject PlayButton { get => playButton; set => playButton = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
