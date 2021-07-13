using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().isStartCount = true;
            GameObject.Find("CameraFollow").GetComponent<SetCameraFollow>().canMove = false;
        }
    }
}
