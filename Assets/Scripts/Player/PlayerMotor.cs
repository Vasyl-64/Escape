using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight = 3f;

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;
    public float gravity = -9.8f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcesMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(
            moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -1.0f * gravity);
        }
    }
}
