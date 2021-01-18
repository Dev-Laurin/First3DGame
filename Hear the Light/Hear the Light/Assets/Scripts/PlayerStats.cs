using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Inventory inventory; 
    Item itemEquipped; 

    // Start is called before the first frame update
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(Item item){
        itemEquipped = item; 
    }

    public void DequipItem(){
        itemEquipped = null; 
    }

    public Item GetEquippedItem(){
        return itemEquipped; 
    }
}
