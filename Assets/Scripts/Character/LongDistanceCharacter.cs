using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongDistanceCharacter : Character
{
    public float fireRate = 1f;
    public float bulletSpeed=7f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    CharacterMoving characterMoving;
    protected override void Start() {
        base.Start();
        characterMoving=GetComponent<CharacterMoving>();
    }
    public override void Attack(GameObject enemy){
        base.Attack(enemy);
        //Shoot();

        //enemy.GetComponent<CharacterStats>().TakeDamage(attackDamage);
    }

    void Shoot()
    {
        base.AttackRotate();
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, gameObject.transform.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if(bullet!=null)
        {
            bullet.Seek(characterMoving.target,attackDamage,bulletSpeed);
        }
    }
}
