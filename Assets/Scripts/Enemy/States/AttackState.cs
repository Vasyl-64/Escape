using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere) * 5);
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 6)
            {
                stateMachine.ChengeState(new SearchState());
            }
        }
    }

    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;

        GameObject bullet = GameObject.Instantiate(enemy.bulletPrefab, gunbarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(0, Vector3.up) * shootDirection * enemy.bulletSpeed;
        shootTimer = 0;
    }
}
