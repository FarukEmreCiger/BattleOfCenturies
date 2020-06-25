using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] characters;
    int selectedCharacter=0;
    // Start is called before the first frame update
    void Start()
    {

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
                    SpawnCharacter(hit.point);
                }
            }
        }

    }
    void SpawnCharacter(Vector3 spawnPoint){
        Vector3 realSpawnPoint= new Vector3(spawnPoint.x,characters[selectedCharacter].transform.position.y,spawnPoint.z);
        GameObject createdCharacter= Instantiate(characters[selectedCharacter]);
        createdCharacter.transform.position=realSpawnPoint;
        createdCharacter.SetActive(true);
    }
}
