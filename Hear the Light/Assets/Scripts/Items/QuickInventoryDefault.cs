using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New QI Default", menuName = "Inventory/DefaultQuickInventory")]
public class QuickInventoryDefault : Item
{   
    public override void Use(){
        base.Use(); 

        Debug.Log("Dequipping " + System.Enum.GetName(typeof(ItemType), type)); 

        //De-Equip the Item 
        GameObject.Find("Player").GetComponent<EquipmentManager>().UnequipItemByTypeName(System.Enum.GetName(typeof(ItemType), type)); 
    }
}
