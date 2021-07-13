using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject playerHolder;
    private bool isDoneCheck;
    public bool isStartCount;
    private int playerCount;
    public bool isCanSave;
    private float timeInterval = .2f;
    private float timeIntervalStart;
    private bool isCanAdd;
    public bool isCanCount;
    private int current;
    private int totalKit;
    private static readonly int EndLevel = Animator.StringToHash("EndLevel");

    void Start()
    {
        playerHolder = GameObject.Find("PlayerHolder");
        timeIntervalStart = timeInterval;
   
    }

    
    void Update()
    {
        
        CheckZeroPlayer();
     
        CountPlayer();
        PlayerSaveStats();
        AddToMeter();
    }

    void CheckZeroPlayer()
    {
        if (playerHolder.transform.childCount <= 0 && !isDoneCheck)
        {
            SceneManager.LoadScene(0);
            isDoneCheck = true;
        }
    }
    
    
    void CountPlayer()
    {  
        if (isStartCount)
        {
            WinPanel();
            playerCount = playerHolder.transform.childCount;
    
        }
    }

    void PlayerSaveStats()
    {
        if (isCanSave)
        {
            current = PlayerPrefs.GetInt("kitness" );
            totalKit = current + playerCount;
            
            isCanAdd = true;
            
            isCanSave = false;
        }
    }

    void AddToMeter()
    {
        if (isCanAdd)
        {
            timeInterval -= Time.deltaTime;
            
            if (timeInterval <= 0 )
            {
                PlayerPrefs.SetInt("kitness", current+1); 
            
                current = PlayerPrefs.GetInt("kitness");
                timeInterval = timeIntervalStart;
                if (current == totalKit)
                {
                    isCanAdd = false;
                }
            }
        }
    }
    
    
    void WinPanel()
    {
        var animator = GameObject.Find("Directional Light").GetComponent<Animator>();
        animator.SetTrigger(EndLevel);
        GameObject.Find("Canvas").transform.Find("WinPanel").gameObject.SetActive(true);
    }
}
 