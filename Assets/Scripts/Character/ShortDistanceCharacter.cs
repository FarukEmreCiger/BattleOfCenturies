using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDistanceCharacter : Character
{
    public override void Attack(GameObject enemy){
        base.Attack(enemy);
        enemy.GetComponent<Character>().TakeDamage(attackDamage);
    }
}
