using System;
using UnityEngine;

[Serializable]
public class ItemSelection
{
    [SerializeField] private LayerMask _collectableMask;
    [SerializeField] private Camera _camera;
    private GameObject _selectedGameObject;
    private Item _selectedItem;
    public bool HasItem => !ReferenceEquals(_selectedItem, null);
    public Item GetItem => _selectedItem;
    public void Search()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f, _collectableMask))
        {
            GameObject hitObj = hit.collider.gameObject;

            if (ReferenceEquals(hitObj, _selectedGameObject))
            {
                return;
            }

            if (!ReferenceEquals(_selectedGameObject, null))
            {
                Unselect();
            }

            Select(hitObj);
        }
        else
        {
            Unselect();
        }
    }

    private void Select(GameObject newSelectedGameObject)
    {
        _selectedGameObject = newSelectedGameObject;
        _selectedItem = newSelectedGameObject.GetComponentInParent<Item>();
        _selectedItem.Select();
    }

    private void Unselect()
    {
        _selectedItem?.Unselect();
        _selectedGameObject = null;
        _selectedItem = null;
    }
}
