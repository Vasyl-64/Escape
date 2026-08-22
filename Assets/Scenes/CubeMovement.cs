using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        Movement(_speed);
    }

    private void Movement(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
