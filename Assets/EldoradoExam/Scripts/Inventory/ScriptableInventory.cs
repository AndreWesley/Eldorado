using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "EldoradoExam/Inventory", order = 1)]
public class ScriptableInventory : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private ScriptableGameEvent _updateUIEvent;
    [SerializeField] private List<Item> _inventory;
    public int InventoryCount => _inventory.Count;
    public Item GetItem(int index)
    {
        return _inventory[index];
    }
    public void Add(Item item)
    {
        item.Deactivate();
        _inventory.Add(item);
        _updateUIEvent.Call();
    }

    public void Remove(Item item)
    {
        // item.Activate();
        _inventory.Remove(item);
        _updateUIEvent.Call();
    }

    public void OnBeforeSerialize()
    {
        _inventory.Clear();
    }
    public void OnAfterDeserialize() { }
}
