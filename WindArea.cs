using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float windSpeed; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement movement = other.GetComponent<Movement>();
            movement.windSpeed = windSpeed;
            movement.isWindArea = true;
            FindObjectOfType<AudioManager>().Play("Wind");
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        var rb = other.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * windSpeed, ForceMode2D.Force );
        
        
 
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement movement = other.GetComponent<Movement>();
            movement.isWindArea = false;
            FindObjectOfType<AudioManager>().Stop("Wind");
        }
      
    }
}
