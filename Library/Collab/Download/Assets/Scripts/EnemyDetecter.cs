using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    public float lookRadius = 10f;
    public float attackRadius = 2f;
    public bool isEnemy;
    public GameObject target;
    List<GameObject> opponents;
    private void Awake()
    {
        if (gameObject.tag == "EnemyCharacter")
        {
            isEnemy = true;
        }
        else if (gameObject.tag == "PlayerCharacter")
        {
            isEnemy = false;
        }
        else
        {
            Debug.LogError("Error 152457");
        }
        SetOpponentList();
        StartDetecting();
    }
    public void StartDetecting()
    {
        if(!IsInvoking("UpdateTarget"))
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    public void StopDetecting(){
        if(IsInvoking("UpdateTarget"))
            CancelInvoke("UpdateTarget");
    }
    private void UpdateTarget()
    {
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = gameObject.transform.position;
        foreach (GameObject character in opponents)
        {
            var distance = Vector3.SqrMagnitude(currentPosition - character.transform.position);//Vector3.Distance(currentPosition, character.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = character;
            }
        }
        if (nearestEnemy != null && (Vector3.Distance(currentPosition, nearestEnemy.transform.position)) <= lookRadius)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }

    }
    void SetOpponentList()
    {
        if (isEnemy)
        {
            opponents = GameManager.playerCharacters;
        }
        else
        {
            opponents = GameManager.enemyCharacters;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
