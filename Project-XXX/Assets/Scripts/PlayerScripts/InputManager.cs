using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerContols _playerControls;

    // Give us Access to our animator values so we can control jesse
    AnimatorManager _animatorManager;

    [Header("Player Movement")] 
    public float VerticalMovementInput;
    public float HorizontalMovementInput;
    private Vector2 _movementInput;

    [Header("Camera Rotation")]
    public float VerticalCameraInput;
    public float HorizontalCameraInput;
    private Vector2 _cameraInput;

    private void Awake()
    {
        _animatorManager = GetComponent<AnimatorManager>();
    }

    void Start()
    {
        Debug.Log(_animatorManager);
    }

    private void OnEnable()
    {
        // If its null do this...
        if (_playerControls == null)
        {
            _playerControls = new PlayerContols();
            // if we press WSAD keys feed input back to the _movementInput.
            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            // if we press MOUSE is detected feed input back to the _cameraInput.
            _playerControls.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
        } 

        _playerControls.Enable();
    }

    private void OnDisable()
    { 
        _playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        // Handle our Movement Input
        HandleMovementInput();
        // Handle our CameraInput
        HandleCameraInput();
        // Handle our SprintInput
    }

    // Edits our Animator Values
    private void HandleMovementInput()
    {
        HorizontalMovementInput = _movementInput.x;
        VerticalMovementInput = _movementInput.y;
        _animatorManager.HandleAnimatorValues(HorizontalMovementInput, VerticalMovementInput);
    }

    private void HandleCameraInput()
    {
        HorizontalCameraInput = _cameraInput.x;
        VerticalCameraInput = _cameraInput.y;
    }
}
