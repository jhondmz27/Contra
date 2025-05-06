using UnityEngine;
using UnityEngine.InputSystem;
public class GatherInput : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private float _valueX;

    public float ValueX { get => _valueX; }

    void Awake()
    {
        controls = new Controls();
    }

    void OnEnable()
    {
        controls.Player.Move.performed += StartMove;
        controls.Player.Move.canceled += StopMove;
        controls.Player.Enable();
    }

    void StartMove(InputAction.CallbackContext context)
    {
        _valueX = context.ReadValue<float>();
    }

    void StopMove(InputAction.CallbackContext context)
    {
        _valueX = 0;
    }

    void OnDisable()
    {
        controls.Player.Move.performed -= StartMove;
        controls.Player.Move.canceled -= StopMove;
        controls.Player.Disable();
    }
}
