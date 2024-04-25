using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MouseLook _mouseLook;
    [SerializeField] private MovementController _moveController;
    [SerializeField] private ItemSelection _itemSelection;
    [SerializeField] private ScriptableGameEvent _switchInventoryPanelEvent;
    [SerializeField] private ScriptableInventory _inventory;

    private Vector2 _directionalInput;
    private Vector2 _lookInput;

    #region Unity Messages
    private void Start()
    {
        _directionalInput = Vector2.zero;
        _lookInput = Vector2.zero;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _moveController.Move(_directionalInput);
        _itemSelection.Search();
    }

    private void LateUpdate()
    {
        _mouseLook.Look(_lookInput);
    }
    #endregion

    #region Actions
    public void MoveAction(InputAction.CallbackContext context)
    {
        _directionalInput = context.ReadValue<Vector2>().normalized;
    }

    public void LookAction(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    public void FireAction(InputAction.CallbackContext context)
    {
        bool pressed = context.ReadValueAsButton();
        if (pressed)
        {
            return;
        }

        if (_itemSelection.HasItem)
        {
            Item item = _itemSelection.GetItem;
            _inventory.Add(item);
            item.gameObject.SetActive(false);
        }
    }

    public void InventoryAction(InputAction.CallbackContext context)
    {
        bool pressed = context.ReadValueAsButton();
        if (!pressed)
        {
            _switchInventoryPanelEvent.Call();
        }
    }
    #endregion
}
