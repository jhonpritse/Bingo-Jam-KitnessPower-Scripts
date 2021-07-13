using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float radius;
    public float power;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void Explode()
    {
        var explosionPos = transform.position;
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(explosionPos, radius);
            foreach (var hit in collider2Ds)
            {
                if (hit.CompareTag("MovableObject"))
                {
                    Rigidbody2D _rb = hit.GetComponent<Rigidbody2D>();
                    _rb.AddForceAtPosition(transform.up *power, explosionPos, ForceMode2D.Impulse);
                }
                if (hit.CompareTag("Player"))
                {
                    Destroy(hit.gameObject, 0.1f);
                }
            }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject);
        }
    }
}
