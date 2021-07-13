using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableVar : MonoBehaviour
{
    public int KitnessValue { get; set; }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        KitnessValue = PlayerPrefs.GetInt("kitness");
    }
}
