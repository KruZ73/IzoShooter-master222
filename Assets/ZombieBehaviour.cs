using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    int hp = 6;

    NavMeshAgent agent;
    Transform player;
    float zhp;

    // GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;



        if(hp> 0)
        {
            transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;

            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
    }

    public void ReceiveDamage(int amount)
    {
        zhp -= amount;
        if (hp <= 0)
            Die();

        
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            hp--;
            if(hp <= 0)
            {
                transform.Translate(Vector3.up);
                transform.Rotate(Vector3.right * -90);
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 5);
            }
        }
    }
}
