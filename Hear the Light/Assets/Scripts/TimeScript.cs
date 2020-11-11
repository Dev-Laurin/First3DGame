﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    private DateTime datetime; 

    // Start is called before the first frame update
    void Start()
    {
        //load time & date from data save 
        //TODO
        datetime = new DateTime(); 
        InvokeRepeating("UpdateTime", .1f, .1f);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTime(){
        datetime.PassTime(); 
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = datetime.GetDateTime();
    }
}
