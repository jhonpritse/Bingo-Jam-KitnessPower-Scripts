using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraFollow : MonoBehaviour
{
 
   

    public bool isFirstMove;
    public bool canMove;
    
    public float moveSpeed;
    void Start()
    {
        isFirstMove = true;
        canMove = false;
    }

    void Update()
    {
      MoveCam(canMove);
    }

    void MoveCam(bool isMove)
    {
        if (isMove)
        {
            var transform1 = transform;
            transform1.position = transform1.position+transform1.right * (moveSpeed * Time.deltaTime);
            isFirstMove = false;
        }
    }




    //
    // void CheckScan()
    // {
    //     if (childCounter != transform.childCount)
    //     {
    //         isScanChild = true;
    //     }
    // }
    // void SetChild()
    // {
    //     if (isScanChild)
    //     {
    //         childTransform = new Transform[transform.childCount];
    //         for (int i = 0; i < transform.childCount; i++)
    //         {
    //             childTransform[i] = gameObject.transform.GetChild(i).transform;
    //         }
    //         childCounter = transform.childCount;
    //         isScanChild = false;  
    //     }
    // }
    //
    //
    
}
