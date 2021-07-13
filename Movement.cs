using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject sprite;
    public GameObject deathParticles;
    public float jumpForce;
    public float moveForce;
    private bool isFly;
    [HideInInspector]  public bool isWindArea;
    [HideInInspector] public float windSpeed;
    [HideInInspector]  public bool isRolling;
    [HideInInspector]  public float rollForce;
    [HideInInspector]   public float rollDuration;

    private Animator anim;
    private static readonly int Flap = Animator.StringToHash("flap");




    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = transform.Find("Circle").gameObject;

    }


    void Update()
    {
        MovementLogic();
    }

    private void FixedUpdate()
    {
        Fly();
        Rolling();
    }

   

    void Rolling()
    {
        if (isRolling)
        {
            rollDuration -= Time.deltaTime;
            foreach (Transform bone in sprite.transform)
            { 
                bone.GetComponent<Rigidbody2D>().AddTorque(-rollForce , ForceMode2D.Impulse);
            }
      
            if (rollDuration <= 0) isRolling = false;
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawSphere(transform.position, .5f);
    // }

    void MovementLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFly = true;
            FindObjectOfType<AudioManager>().Play("FlapWings");
        }
    }

    void Fly()
    {
        if (isFly)
        {
            
            if (!isWindArea)
            {
                rb.AddForce(new Vector2(moveForce, jumpForce), ForceMode2D.Force);
                foreach (Transform bone in sprite.transform)
                { 
                    var rb2d = bone.GetComponent<Rigidbody2D>();
                    rb2d.AddForce(new Vector2(moveForce, jumpForce), ForceMode2D.Force);
                }

                
                foreach (Transform bone in sprite.transform)
                {
                    var rb2d = bone.GetComponent<Rigidbody2D>();
                    rb2d.velocity = new Vector2(0, 0);
                }
            }
           
            isFly = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Environment/Wind"))
        {
            isWindArea = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Environment/Wind"))
        {
            isWindArea = false;
        }
    }

    private void OnDestroy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
    }
}
