using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSearching : MonoBehaviour
{
    [SerializeField] private LayerMask _collectableMask;
    [SerializeField] private Camera _camera;
    private GameObject _selectedGameObject;
    private Item _selectedItem;

    public void SearchItems()
    {
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f, _collectableMask))
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
        _selectedItem = newSelectedGameObject.GetComponent<Item>();
    }

    private void Unselect()
    {
        _selectedItem?.Unselect();
        _selectedGameObject = null;
        _selectedItem = null;
    }
}
