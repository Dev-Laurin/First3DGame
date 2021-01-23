using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int idCounter; 
    // Start is called before the first frame update
    void Start()
    {
        idCounter = 0; 
    }

    public int GetNewID(){
        idCounter += 1; 
        return idCounter; 
    }
}
