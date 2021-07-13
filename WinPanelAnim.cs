using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelAnim : MonoBehaviour
{

    public void StartCount()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().isCanSave = true; 
    }
}
