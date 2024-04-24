using System;
using UnityEngine;

[Serializable]
public class MouseLook
{
    [SerializeField] private Transform _horizontalRotationRef;
    [SerializeField] private Transform _verticalRotationRef;
    [SerializeField] private float _sensibility = 1f;

    public void Look(Vector2 lookInput)
    {
        lookInput *= _sensibility * Time.deltaTime;
        _horizontalRotationRef.Rotate(Vector3.up, lookInput.x);
        _verticalRotationRef.Rotate(Vector3.right, -lookInput.y);
    }
}
