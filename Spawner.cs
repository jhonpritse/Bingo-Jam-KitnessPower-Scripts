using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public int amount;
    private float spawnRate = 0.1f;
    private float spawnCounter;
    private bool isStart = false;
    private int i = 0;
    
    public Transform[] pos;

    private float playerSize;
    void Start()
    {
        spawnCounter = spawnRate;
    }

    private void Update()
    {
        Multiply();
    }

    void Spawn()
    {
        var spawned=  Instantiate(playerPrefab,pos[0+i].position, Quaternion.identity);
        SetRightSize(spawned, playerSize);
        FindObjectOfType<AudioManager>().Play("Collect");
        i++;
        
        amount--;
        if (amount <= 0)
        {   
     
            Destroy(gameObject);
        }
    }

    void SetRightSize(GameObject spawned , float size)
    {
        if (size <= 0.5f)
        {
           ModifySize(spawned, 0.18f, 1.2f);
        }else if (size <= 1 )
        {
            ModifySize(spawned, 0.38f, 1.5f);
        }
        else
        {
            ModifySize(spawned, 0.78f, 1.6f);
        }
    }
    void ModifySize(GameObject spawned,float radius, float mass)
    {
        spawned.GetComponent<CircleCollider2D>().radius = radius;
        spawned.transform.Find("Circle").localScale =  new Vector3(playerSize, playerSize);
            
        foreach (Transform bone in spawned.transform.Find("Circle").transform)
        {
            bone.GetComponent<Rigidbody2D>().mass = mass;
        }
    }

    
    void Multiply()
    {
        if (isStart)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                Spawn();
                spawnCounter = spawnRate;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            var scale = player.transform.Find("Circle").localScale.x;
            playerSize = scale;
            
            isStart = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    
}