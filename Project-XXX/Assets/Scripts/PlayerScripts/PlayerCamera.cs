using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public InputManager InputManager;

    public Transform CameraPivot;
    public Camera CameraObject;
    public GameObject Player; // Object that the camera will follow;


    Vector3 _cameraFollowVelocity;
    Vector3 _targetPosition;
    Vector3 _cameraRotation;
    private Quaternion _targetRotation;

    [Header("Camera Speeds")] float _cameraSmoothTime = 0.2f;

    float _lookAmountVertical;
    float _lookAmountHorizontal;
    public float MaximumPivotAngle = 15.0f;
    public float MinimumPivotAngle = -15.0f;

    public void CameraMovementManager()
    {
        // Follow the player
        FollowPlayer();
        // Rotate the camera around player
        RotateCamera();
    }

    private void FollowPlayer()
    {
        _targetPosition = Vector3.SmoothDamp(transform.position, Player.transform.position, ref _cameraFollowVelocity,
            _cameraSmoothTime * Time.deltaTime);
        transform.position = _targetPosition;
    }

    private void RotateCamera()
    {
        _lookAmountVertical += (InputManager.HorizontalCameraInput);
        _lookAmountHorizontal -= (InputManager.VerticalCameraInput);
        // Locks the value between min and max
        _lookAmountHorizontal = Mathf.Clamp(_lookAmountHorizontal, MinimumPivotAngle, MaximumPivotAngle);

        _cameraRotation = Vector3.zero;
        _cameraRotation.y = _lookAmountVertical;
        _targetRotation = Quaternion.Euler(_cameraRotation);
        _targetRotation = Quaternion.Slerp(transform.rotation, _targetRotation, _cameraSmoothTime);
        transform.rotation = _targetRotation;

        _cameraRotation = Vector3.zero;
        _cameraRotation.x = _lookAmountHorizontal;
        _targetRotation = Quaternion.Euler(_cameraRotation);
        _targetRotation = Quaternion.Slerp(CameraPivot.localRotation, _targetRotation, _cameraSmoothTime);
        CameraPivot.localRotation = _targetRotation;
    }   
}
