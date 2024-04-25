using System;
using UnityEngine;

[Serializable]
public class MovementController
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _SpeedMultiplier = 100f;
    [SerializeField] private float _rightSpeed = 3f;
    [SerializeField] private float _forwardSpeed = 5f;
    [SerializeField] private float _backwardSpeed = 2f;

    public void Move(Vector2 directionalInput)
    {
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right.normalized;
        forward.y = 0;
        right.y = 0f;

        float yAxisSpeed = directionalInput.y > 0f ? _forwardSpeed : _backwardSpeed;

        Vector3 moveRight = right * directionalInput.x * _rightSpeed * _SpeedMultiplier;
        Vector3 moveForward = forward * directionalInput.y * yAxisSpeed * _SpeedMultiplier;
        Vector3 speed = (moveRight + moveForward + Physics.gravity) * Time.fixedDeltaTime;

        _characterController.SimpleMove(speed);
    }
}