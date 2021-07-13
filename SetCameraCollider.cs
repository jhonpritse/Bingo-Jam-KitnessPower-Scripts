using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetCameraCollider : MonoBehaviour
{
    private SetCameraFollow cameraFollow;
    private CinemachineVirtualCamera cam;
    private float normalSpeed;
    private float chaiseSpeed;
    void Start()
    {
        cam = GameObject.Find("CM_vcam1").GetComponent<CinemachineVirtualCamera>();
        if (transform.name != "StartFollow")
        {
            cameraFollow = transform.parent.GetComponent<SetCameraFollow>();
            normalSpeed = cameraFollow.moveSpeed;
            chaiseSpeed = cameraFollow.moveSpeed * 7f;
        }
        
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (transform.name == ("StartFollow"))
        {
            var cameraFollow2 = GameObject.Find("CameraFollow").GetComponent<SetCameraFollow>();
            if (other.CompareTag("Player") && cameraFollow2.isFirstMove)
            {
                cameraFollow2.canMove = true;
                cam.Follow = cameraFollow2.transform;
            }
        }
       
        if ( transform.name ==("Destroy"))
        {
            if (other.CompareTag("Player") && cameraFollow.canMove)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (transform.name == ("SpeedUp"))
        {
            if (other.CompareTag("Player") && cameraFollow.canMove)
            {
                cameraFollow.moveSpeed = chaiseSpeed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (transform.name == ("SpeedUp"))
        {
            if (other.CompareTag("Player") && cameraFollow.canMove)
            {
                cameraFollow.moveSpeed = normalSpeed;
            }
        }
    }
}
