using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Vector3 direction;

    public void Initialize(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
        }

        Destroy(gameObject);
    }
}
