using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class hp : MonoBehaviour
{

    public GameObject hpPrefab;
    private int maxHp = 2;
    int hpp = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hp = GameObject.FindGameObjectsWithTag("Hp");


        if (hp.Count() < maxHp)
        {
            SpawnHp();
        }
    }

    void SpawnHp()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * Random.Range(10, 15);
        spawnPosition.y = 1;


        if (Physics.CheckSphere(spawnPosition, 0.9f))
        {
            spawnPosition = Random.insideUnitSphere * Random.Range(10, 15);
            spawnPosition.y = 0;
        }

        GameObject newHp = Instantiate(hpPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        position = position.normalized * Random.Range(10, 15);
        return position;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            hpp--;
            if (hpp <= 0)
            {
                transform.Translate(Vector3.up);
                transform.Rotate(Vector3.right * -90);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 5);
            }
        }
    }

}
