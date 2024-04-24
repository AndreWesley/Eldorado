using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] MeshRenderer _renderer;
    [SerializeField] Color _selectedColor;
    [SerializeField] ScriptableItem _scriptableItem;

    public void Select()
    {
        _renderer.material.color = _selectedColor;
    }

    public void Unselect()
    {
        _renderer.material.color = Color.white;
    }

    public ScriptableItem ScriptableItem => _scriptableItem;
}
