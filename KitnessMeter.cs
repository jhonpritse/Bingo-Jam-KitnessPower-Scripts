using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KitnessMeter : MonoBehaviour
{
    private Slider slider;
    private SavableVar savableVar;

    private int oldValue;
    private int newValue;

    private bool firstRun = true;

    private TextMeshProUGUI text;
    void Start()
    {
        slider = GetComponent<Slider>();
        savableVar = GameObject.Find("Savable Manager").GetComponent<SavableVar>();

        var handle = transform.Find("Handle Slide Area");
        var handleChild = handle.transform.Find("Handle");
        text = handleChild.transform.Find("Percentage").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        slider.value = savableVar.KitnessValue;
        newValue = (int)slider.value;
        
        if (firstRun)
        {
            MeterPercent(newValue);
            oldValue = newValue;
            firstRun = false;
        }
        if (newValue != oldValue)
        {
            PerValueChange();
        }
        MeterPercent(newValue);
        oldValue = newValue;
        
    }

    void PerValueChange()
    {
        // print("added");
    }

    void MeterPercent(int value)
    {
        text.text = (value + "%");
    }
}
