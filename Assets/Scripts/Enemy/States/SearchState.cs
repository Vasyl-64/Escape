using UnityEngine;

public class SearchState : BaseState
{
    private float searchTime;
    private float moveTimer;
    
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
            stateMachine.ChengeState(new AttackState());

        if (enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            searchTime += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (searchTime > 6)
            {
                stateMachine.ChengeState(new PatrolState());
            }
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere) * 5);
                moveTimer = 0;
            }
        }
    }

    public override void Exit()
    {
        
    }
}
