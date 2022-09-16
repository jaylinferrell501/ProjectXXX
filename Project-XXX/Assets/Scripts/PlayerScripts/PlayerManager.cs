using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerCamera _playerCamera;
    InputManager _inputManager;
    PlayerLocoMotionManager _playerLocoMotionManager;
    private void Awake()
    {
        _playerCamera = FindObjectOfType<PlayerCamera>();
        _inputManager = GetComponent<InputManager>();
        _playerLocoMotionManager = GetComponent<PlayerLocoMotionManager>();
    }
    private void Update()
    {
        _inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        _playerLocoMotionManager.HandleAllLocomotion();
    }

    private void LateUpdate()
    {
        _playerCamera.CameraMovementManager();
    }
}
