using UnityEngine;
using UnityEngine.InputSystem;

public class InputService : MonoBehaviour
{
    public InputActionReference moveInput;
    public InputActionReference attackInput;

    public Vector2 MoveInput => moveInput.action.ReadValue<Vector2>();
    public bool AttackPressed => attackInput.action.WasPressedThisFrame();
}