using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Path path;
    private GameObject player;
    public GameObject Player { get => player; }

    public GameObject bulletPrefab;
    public float bulletSpeed = 60f;

    [SerializeField] private int _timesToKill = 3;
    [SerializeField] private string currntState;
    public Transform gunBarrel;
    [Range(1.0f, 10f)]
    public float fireRate;

    public float sightDistance = 20f;
    public float fieldOfView = 90f;
    public float eyeHeight;
    private Vector3 lastKnowPos;
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }

    private float _maxHP = 100f;
    private float _HP;

    private void Start()
    {
        _HP = _maxHP;

        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();

        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        currntState = stateMachine.activeState.ToString();
    }

    private void TakeDamage()
    {
        _HP -= (_maxHP / _timesToKill);
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (_HP <= 0)
            Destroy(gameObject);
    }

    public void Hit()
    {
        TakeDamage();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer <= fieldOfView / 2f)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection.normalized);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, sightDistance))
                    {
                        if (hit.collider.CompareTag("Player"))
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.green);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
