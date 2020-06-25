using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static void SpawnCharacter(GameObject character ,Vector3 spawnPoint,Directions direction){
        Vector3 realSpawnPoint= new Vector3(spawnPoint.x,character.transform.position.y,spawnPoint.z);
        GameObject createdCharacter= Instantiate(character);
        createdCharacter.transform.position=realSpawnPoint;
        if(direction==Directions.PlayerBuilding){
            createdCharacter.transform.Rotate(0,180,0);
            createdCharacter.tag="EnemyCharacter";
            GameManager.enemyCharacters.Add(createdCharacter);
        }
        else{
            createdCharacter.tag="PlayerCharacter";
            GameManager.playerCharacters.Add(createdCharacter);
        }
        createdCharacter.SetActive(true);
        
    }
}
