using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    CharacterMoving movement;
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public float health;
    public float attackDamage;
    public float runSpeed;
    public float attackSpeed;
    private void Start()
    {
        movement = GetComponent<CharacterMoving>();
    }
    private void TakeDamage(float damage)
    {
        if (health - damage > 0)
            health -= damage;
        else
        {
            health = 0;
            if(movement.isEnemy)
                GameManager.enemyCharacters.Remove(gameObject);
            else
                GameManager.playerCharacters.Remove(gameObject);
            Destroy(gameObject);
            //TODO Öldürülecek
        }

    }
    public void Attack(GameObject enemy)
    {
        AttackAnimation();
        enemy.GetComponent<CharacterStats>().TakeDamage(attackDamage);

    }
    void AttackAnimation()
    {
        Vector3 dir = movement.target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(gameObject.transform.rotation, lookRotation,500).eulerAngles;
        gameObject.transform.rotation = lookRotation;
        movement.animator.SetTrigger("Attack");
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
