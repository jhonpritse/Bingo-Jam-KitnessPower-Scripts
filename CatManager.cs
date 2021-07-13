using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatManager : MonoBehaviour
{
   
    void Start()
    {
        
    }

  
    void Update()
    {
        var KitnessValue = PlayerPrefs.GetInt("kitness");
   
        for (int i = 0; i < KitnessValue; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(true);
        }
    }
}
