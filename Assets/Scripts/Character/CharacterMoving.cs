using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum Directions
{
    EnemyBuilding,
    PlayerBuilding
}
public class CharacterMoving : MonoBehaviour
{
    public List<GameObject> opponents;
    EnemyDetecter enemyDetecter;
    Directions direction;
    public GameObject target;
    Character characterStats;
    NavMeshAgent agent;
    public Animator animator;
    void Start()
    {
        enemyDetecter = GetComponent<EnemyDetecter>();
        if (enemyDetecter.isEnemy)
        {
            direction = Directions.PlayerBuilding;
        }
        else
        {
            direction = Directions.EnemyBuilding;
        }
        characterStats = GetComponent<Character>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        InvokeDecider();
        InvokeMoveCharacter();
        InvokeAttackOrMove();
    }

    void InvokeDecider()
    {
        enemyDetecter.StartDetecting();
        if (!IsInvoking("Decider"))
            InvokeRepeating("Decider", 0f, 0.5f);
    }
    void InvokeMoveCharacter()
    {
        if (!IsInvoking("MoveCharacter"))
            InvokeRepeating("MoveCharacter", 0f, 0.5f);

    }
    void InvokeAttackOrMove()
    {
        if (!IsInvoking("AttackOrMove"))
            InvokeRepeating("AttackOrMove", 0f, 0.5f);
    }
    public void MoveCharacter()
    {
        animator.SetBool("Walk", true);
        if (target == null)
        {
            agent.SetDestination(enemyDetecter.isEnemy ? GameManager.playerBuilding.transform.position : GameManager.enemyBuilding.transform.position);
        }
        else
        {
            agent.SetDestination(target.transform.position);
        }

    }
    //TODO Performans artırımı için bakılacak
    private void Decider()
    {
        if (target != null)
        {
            CancelInvoke("Decider");
            enemyDetecter.StopDetecting();
            return;
        }
        target = enemyDetecter.target;
        
    }

    void AttackOrMove()
    {
        if (target == null)
        {
            InvokeDecider();
            InvokeMoveCharacter();
        }
        else
        {
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) > enemyDetecter.attackRadius)
            {
                InvokeMoveCharacter();
            }
            else
            {
                if (IsInvoking("MoveCharacter"))
                {
                    CancelInvoke("MoveCharacter");
                    animator.SetBool("Walk", false);
                }
                characterStats.Attack(target);
            }

        }
    }
}
