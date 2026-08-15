using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PauseGame pause;

    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerShooting shooting;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        shooting = GetComponent<PlayerShooting>();

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Tap.performed += ctx => shooting.Shoot();
        onFoot.PressTap.performed += ctx => pause.TogglePause();
    }

    private void FixedUpdate()
    {
        motor.ProcesMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
