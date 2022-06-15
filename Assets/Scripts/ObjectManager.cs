using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager instance;
    [SerializeField] private Transform playerObject;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform camera;
    [SerializeField] private TextMeshProUGUI scoreText;


    public static ObjectManager Instance { get => instance; set => instance = value; }
    public Transform PlayerObject { get => playerObject; set => playerObject = value; }
    public GameObject NextButton { get => nextButton; set => nextButton = value; }
    public GameObject RetryButton { get => retryButton; set => retryButton = value; }
    public GameObject PlayButton { get => playButton; set => playButton = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public TextMeshProUGUI ScoreText { get => scoreText; set => scoreText = value; }
    public Transform Camera { get => camera; set => camera = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
