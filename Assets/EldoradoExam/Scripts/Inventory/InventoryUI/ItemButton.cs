using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private ScriptableInventory _scriptableInventory;
    [SerializeField] private float _throwForce = 5f;
    private Item _item;

    public void RestoreItem()
    {
        _scriptableInventory.Remove(_item);
        _item.Throw(_throwForce);
    }

    public void SetItem(Item item)
    {
        _item = item;
        _image.sprite = item.ScriptableItem.Icon;
    }

    public Image Image => _image;
}
