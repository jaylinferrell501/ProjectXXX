using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocoMotionManager : MonoBehaviour
{
    InputManager _inputManager;

    [Header("Camera Transform")]
    public Transform PlayerCamera;

    [Header("Movement Speed")] 
    public float RotationSpeed = 3.5f; // How fast do you want to rotate.

    [Header("Rotation Variables")] 
    Quaternion _targetRotation; // The place we want to rotate
    Quaternion _playerRotation; // The place we are now, (Constantly changing)

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    public void HandleAllLocomotion()
    {
        // Handles our Rotation
        HandleRotation();
        // Handles falling
    }

    public void HandleRotation()
    {
        // we only want to rotate the direction the camera is facing
        _targetRotation = Quaternion.Euler(0, PlayerCamera.eulerAngles.y, 0);
        _playerRotation = Quaternion.Slerp(transform.rotation, _targetRotation, RotationSpeed * Time.deltaTime);

        // only rotate if we are moving
        if (_inputManager.VerticalMovementInput != 0 || _inputManager.HorizontalMovementInput != 0)
        {
            transform.rotation = _playerRotation;
        }
    }
}
