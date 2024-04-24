using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private MouseLook _headController;
    [SerializeField] private MovementController _moveController;

    private Vector2 _directionalInput;
    private Vector2 _lookInput;
    private bool _runPressed;

    #region Unity Messages
    private void Start()
    {
        _directionalInput = Vector2.zero;
        _lookInput = Vector2.zero;
        _runPressed = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _moveController.Move(_directionalInput);
    }

    private void LateUpdate()
    {
        _headController.Look(_lookInput);
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
        Debug.Log("fire pressed: " + pressed);
    }
    #endregion
}
