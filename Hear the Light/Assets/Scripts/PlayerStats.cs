﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public GameObject stomachUI; 
    public GameObject waterUI; 
    public GameObject strengthUI; 

    //Percentages 
    int thirst; 
    int hunger; 
    int strength;  

    bool timeToDrain = false; 

    void Start(){
        //Load from save 
        thirst = 100; 
        hunger = 100; 
        strength = 100; 

        InvokeRepeating("DrainSurvivalStats", 5f, 5f); 
    }

    private void DrainSurvivalStats(){
        thirst--; 
        hunger--; 
        strength--; 

        UpdateUI(); 
    }

    private void UpdateUI(){
        stomachUI.GetComponent<TMPro.TextMeshProUGUI>().text = hunger + "%"; 
        waterUI.GetComponent<TMPro.TextMeshProUGUI>().text = thirst + "%"; 
        strengthUI.GetComponent<TMPro.TextMeshProUGUI>().text = strength + "%"; 
    }
}
