using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
   public Item item; 

    public override void Interact(){
        base.Interact(); 
        
        //add to inventory 
        if(GameObject.Find("Player").GetComponent<Inventory>().AddItem(item)){
            Debug.Log("Placing " + item.name + " in inventory."); 
            Destroy(gameObject);
        } 
        else{
            Debug.Log("Inventory full."); 
        }
         
    }
}
