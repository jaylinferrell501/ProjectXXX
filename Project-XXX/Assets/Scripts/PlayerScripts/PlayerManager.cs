using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerCamera _playerCamera;
    InputManager _inputManager;
    private void Awake()
    {
        _playerCamera = FindObjectOfType<PlayerCamera>();
        _inputManager = GetComponent<InputManager>();
    }

    void Start()
    {
        Debug.Log(_inputManager);
    }

    private void Update()
    {
        _inputManager.HandleAllInputs();
    }

    private void LateUpdate()
    {
        _playerCamera.CameraMovementManager();
    }
}
