using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instance is null");
            }

            return _instance;
        }
    }

    [SerializeField] public KeyCode Jump = KeyCode.Space;
    [SerializeField] public KeyCode WalkRight = KeyCode.D;
    [SerializeField] public KeyCode WalkLeft = KeyCode.A;
    [SerializeField] public KeyCode Interact = KeyCode.E;

    

    private void Awake()
    {
        _instance = this;
    }
    
    
}
