using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntilledGround : Interactable
{

    public GameObject tilledGround; 
    // Start is called before the first frame update
    public override void Interact(){
        base.Interact(); 

        //is equipped item able to till this? 
        Item item = GameObject.Find("Player").GetComponent<EquipmentManager>().GetEquippedItem("Weapon"); 
        if(item != null){
            if(item.name == "Shovel"){
                //change to tilled ground gameobject 
                Transform thisPos = transform; 
                Instantiate(tilledGround, transform.position, Quaternion.identity); 
                Destroy(gameObject);
            }
        }
    }
}
