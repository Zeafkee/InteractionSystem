using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput m_PlayerInput;

    private InputAction m_MoveAction;
    private InputAction m_InteractAction;
    private InputAction m_SprintAction;

    private void Awake()
    {
        InitializeInputs();
    }
    void InitializeInputs()
    {
        m_MoveAction = m_PlayerInput.actions["Move"];
        m_InteractAction = m_PlayerInput.actions["Interact"];
        m_SprintAction = m_PlayerInput.actions["Sprint"];


    }
    #region Methods
    public Vector2 GetMoveInput()
    {
        return m_MoveAction.ReadValue<Vector2>();
    }
    public bool GetInteractInput()
    {
        return m_InteractAction.triggered;
    }
    public Vector2 GetMouseScrollInput()
    {
        return Mouse.current.scroll.ReadValue();
    }
    public bool GetSprintInput()
    {
        return m_SprintAction.IsPressed();
    }

    #endregion
}
