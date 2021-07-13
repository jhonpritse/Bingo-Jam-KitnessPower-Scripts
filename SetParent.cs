using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    private Transform parent;
    void Awake()
    {
        parent = GameObject.Find("PlayerHolder").transform;
        gameObject.transform.parent = parent;
    }
    
}
