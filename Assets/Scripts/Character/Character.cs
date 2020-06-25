using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ParticleSystem bloodParticles;
    CharacterMoving movement;
    protected EnemyDetecter enemyDetecter;

    public float health;
    public float attackDamage;
    public float runSpeed;
    public float attackSpeed;
    protected virtual void Start()
    {
        enemyDetecter = GetComponent<EnemyDetecter>();
        movement = GetComponent<CharacterMoving>();
        bloodParticles = gameObject.GetComponentInChildren<ParticleSystem>();

    }
    public void TakeDamage(float damage)
    {
        bloodParticles.Play();
        if (health - damage > 0)
            health -= damage;
        else
        {
            health = 0;
            if (enemyDetecter.isEnemy)
                GameManager.enemyCharacters.Remove(gameObject);
            else
                GameManager.playerCharacters.Remove(gameObject);
            //TODO Öldürülecek
            //TODO Reward Verilecek
            Destroy(gameObject);

        }

    }
    public virtual void Attack(GameObject enemy)
    {
        AttackAnimation();
    }
    public void AttackAnimation()
    {
        AttackRotate();
        movement.animator.SetTrigger("Attack");
    }
    public void AttackRotate()
    {
        Vector3 dir = movement.target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        gameObject.transform.rotation = lookRotation;
    }

}
