using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TillGround : MonoBehaviour
{

    public GameObject tilledGround; 

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //change to tilled ground gameobject 
            Transform thisPos = transform; 
            Instantiate(tilledGround, transform.position, Quaternion.identity); 
            Destroy(gameObject); 
        }
    }
}
