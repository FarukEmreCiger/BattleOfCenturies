using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private GameManager()  
    {  
    }  
    private static GameManager instance;  
    public static GameManager Instance(){
        return instance;
    }
    public GameObject[] allCharacters;
    public static GameObject enemyBuilding;
    public static GameObject playerBuilding;
    public static List<GameObject> enemyCharacters=new List<GameObject>();
    public static List<GameObject> playerCharacters=new List<GameObject>();
    private void Awake() {
        instance = this;  
        enemyBuilding=GameObject.FindGameObjectWithTag("EnemyBuilding");
        playerBuilding=GameObject.FindGameObjectWithTag("PlayerBuilding");
    }
}
