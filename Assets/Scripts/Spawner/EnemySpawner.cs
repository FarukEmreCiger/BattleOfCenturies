using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawner=true;
    public GameObject[] enemyCharacters;
    int selectedCharacter = 0;
    Vector3 centerPoint;
    float sizeX, sizeZ;
    public float spawnDelay;

    void Start()
    {
        enemyCharacters = GameManager.Instance().allCharacters;
        GameObject zone = GameObject.FindGameObjectWithTag("EnemyZone");
        centerPoint = zone.transform.position;
        sizeX = zone.transform.lossyScale.x;
        sizeZ = zone.transform.lossyScale.z;
        StartCoroutine(SpawnEnemy());

    }

    public IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        float randomX = Random.Range(-sizeX / 2, sizeX / 2);
        float randomZ = Random.Range(-sizeZ / 2, sizeZ / 2);
        Vector3 randomSpawnPoint = centerPoint + (new Vector3(randomX, 0, randomZ));

        if (spawner)
        {
            selectedCharacter=(selectedCharacter+1)%(enemyCharacters.Length);//Temporary Code For Seeing All the Characters
            Spawner.SpawnCharacter(enemyCharacters[selectedCharacter], randomSpawnPoint, Directions.PlayerBuilding);

        }
        StartCoroutine(SpawnEnemy());

    }
}
