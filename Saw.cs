using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private Rigidbody2D rb; 
    [Range(0, 500)] public float rotationSpeed;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        Rotation();
    }
    void Rotation()
    {
        transform.eulerAngles = Vector3.forward * (rotationSpeed * Time.time);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var particleManager = GameObject.Find("Particle Manager").GetComponent<ParticleManager>();
        if (other.transform.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            foreach (var contact in other.contacts)
            {
                var hit = Instantiate(particleManager.splat, contact.point, Quaternion.identity);
                hit.transform.parent = gameObject.transform;
            }
            Destroy(other.gameObject);
        }
    }

   
}
