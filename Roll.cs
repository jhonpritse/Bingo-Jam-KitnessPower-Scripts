using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float rollDuration;
    public float rollForce;
    private bool issearch;

    private void Update()
    {
        if (issearch)
        {
            var playerHolder = GameObject.Find("PlayerHolder");

            for (int i = 0; i < playerHolder.transform.childCount; i++)
            {
                var child = playerHolder.transform.GetChild(i);
                Movement movement = child.GetComponent<Movement>();
                movement.rollDuration = rollDuration;
                movement.rollForce = rollForce;
                movement.isRolling = true;
            }
            FindObjectOfType<AudioManager>().Play("Collect");
            Destroy(gameObject);
                
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            issearch = true;
            
        }  
    }

   
}
 