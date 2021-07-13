using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private Vector2 playerPos;
    private GameObject playerHolder;
    public float startDistance;
    public MonoBehaviour scriptToActivate;
    
    
    void Start()
    {
        PlayerOutRange();
        playerHolder = GameObject.Find("PlayerHolder");
    }
    
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, startDistance);
    // }

    void Update()
    {
        CheckPlayerPos();
    }

    void PlayerInRange()
    {
        scriptToActivate.enabled = true;
    }
    void PlayerOutRange()
    {
        scriptToActivate.enabled = false;
    }
    private void CheckPlayerPos()
    {
        foreach (Transform childPlayer in playerHolder.transform)
        {
            float distanceSqr = (transform.position - childPlayer.position).sqrMagnitude;
              
                if ( distanceSqr < startDistance*startDistance)
                {
                    PlayerInRange();
                }
                if (distanceSqr > startDistance * startDistance)
                {
                    PlayerOutRange();
                } 
        }  
        
    }

}
