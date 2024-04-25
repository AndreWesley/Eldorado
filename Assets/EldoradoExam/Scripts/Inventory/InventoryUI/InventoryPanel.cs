using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private RectTransform _panelRectTransform;
    [SerializeField] private HorizontalLayoutGroup _layout;
    [SerializeField] private ScriptableInventory _inventory;
    [SerializeField] private float _contentWidth = 100f;
    [SerializeField] private ItemButton[] _slots;

    private bool _isOpen;

    private void Start()
    {
        Close();
    }

    public void UpdateUI()
    {
        int storedAmount = _inventory.InventoryCount;
        int slotsAmount = _slots.Length <= storedAmount ? _slots.Length : storedAmount;

        for (int i = 0; i < slotsAmount; i++)
        {
            Item item = _inventory.GetItem(i);
            _slots[i].SetItem(item);
        }

        UpdatePanelSize();
    }

    public void SwitchPanelStatus()
    {
        if (_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private float CalculateOpenSize()
    {
        int storedAmount = _inventory.InventoryCount;
        float spacing = _layout.spacing;
        float baseSize = spacing + spacing + _contentWidth;
        float inventorySize = (_contentWidth + spacing) * storedAmount;

        Debug.Log("baseSize: " + baseSize);
        Debug.Log("storedAmount: " + storedAmount);
        Debug.Log("inventorySize: " + inventorySize);


        return baseSize + inventorySize;
    }

    private void Open()
    {
        Cursor.lockState = CursorLockMode.None;
        float size = CalculateOpenSize();
        Vector2 panelSize = _panelRectTransform.sizeDelta;
        _panelRectTransform.sizeDelta = new Vector2(size, panelSize.y);

        _isOpen = true;
    }

    private void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        float spacing = _layout.spacing;
        float closedSize = spacing + spacing + _contentWidth;

        Vector2 panelSize = _panelRectTransform.sizeDelta;
        _panelRectTransform.sizeDelta = new Vector2(closedSize, panelSize.y);

        _isOpen = false;
    }

    private void UpdatePanelSize()
    {
        if (_isOpen)
        {
            Open();
            return;
        }

        Close();
    }
}
