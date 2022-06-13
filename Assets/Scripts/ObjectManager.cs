using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private static ObjectManager instance;
    [SerializeField] private Transform playerObject;

    public static ObjectManager Instance { get => instance; set => instance = value; }
    public Transform PlayerObject { get => playerObject; set => playerObject = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
