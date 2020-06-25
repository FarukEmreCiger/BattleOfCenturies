using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerCharacters;
    int selectedCharacter = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerCharacters = GameManager.Instance().allCharacters;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("PlayerZone"))
                {
                    Debug.Log(playerCharacters.Length);
                    selectedCharacter = (selectedCharacter + 1) % (playerCharacters.Length);//Temporary Code For Seeing All the Characters
                    Spawner.SpawnCharacter(playerCharacters[selectedCharacter], hit.point, Directions.EnemyBuilding);
                }
            }
        }

    }

}
