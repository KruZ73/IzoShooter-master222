using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject ZombiePrefab;
    private int maxZombies = 4;

    void Start()
    {
        
    }
    void Update()
    {
        var zombies = GameObject.FindGameObjectsWithTag("Enemy");


        if (zombies.Count() < maxZombies)
        {
            SpawnZombie();
        }

    }

    void SpawnZombie()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * Random.Range(10, 15);
        spawnPosition.y = 1;


        if (Physics.CheckSphere(spawnPosition, 0.9f))
        {
            spawnPosition = Random.insideUnitSphere * Random.Range(10, 15);
            spawnPosition.y = 0;
        }

        GameObject newZombie = Instantiate(ZombiePrefab, spawnPosition, Quaternion.identity);
    }





    Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        position = position.normalized * Random.Range(10, 15);
        return position;
    }

}
