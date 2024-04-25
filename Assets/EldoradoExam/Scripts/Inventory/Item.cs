using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Color _selectedColor;
    [SerializeField] ScriptableItem _scriptableItem;
    [SerializeField] Rigidbody _rigidbody;

    public void Select()
    {
        _renderer.material.color = _selectedColor;
    }

    public void Unselect()
    {
        _renderer.material.color = Color.white;
    }

    internal void Deactivate()
    {
        gameObject.SetActive(false);
    }

    internal void Throw(float force)
    {
        Transform camTransform = Camera.main.transform;
        Vector3 throwVelocity = camTransform.forward * force;

        _rigidbody.position = camTransform.position;
        _rigidbody.velocity = throwVelocity;

        gameObject.SetActive(true);
    }

    public ScriptableItem ScriptableItem => _scriptableItem;
}
