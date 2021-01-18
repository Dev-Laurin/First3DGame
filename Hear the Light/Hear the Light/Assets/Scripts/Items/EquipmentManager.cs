using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public delegate void OnEquipmentChange(Equipment newItem, Equipment oldItem); 
    public OnEquipmentChange OnEquipmentChanged; 

    Equipment[] currentEquipment;
    Inventory inventory;  

    void Start(){
        inventory = GameObject.Find("Player").GetComponent<Inventory>(); 
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; 
        currentEquipment = new Equipment[numSlots]; 
    }

    public Item GetEquippedItem(string itemType){
        if (System.Enum.IsDefined(typeof(EquipmentSlot), itemType)){
            return currentEquipment[(int)(EquipmentSlot)System.Enum.Parse(typeof(EquipmentSlot), itemType)]; 
        }
        return null; 
    }

    public void Equip(Equipment newItem){
        int slotIndex = (int)newItem.equipSlot; 

        Equipment oldItem = null; 
        if(currentEquipment[slotIndex] != null){
            oldItem = currentEquipment[slotIndex]; 
            inventory.AddItem(oldItem); 
        }

        //callbacks 
        if (OnEquipmentChanged != null){
            OnEquipmentChanged.Invoke(newItem, oldItem); 
        }

        currentEquipment[slotIndex] = newItem; 
    }

    public void Unequip(int slotIndex){
        if(currentEquipment[slotIndex] != null){
            Equipment oldItem = currentEquipment[slotIndex]; 
            inventory.AddItem(oldItem); 

            currentEquipment[slotIndex] = null; 

            //callbacks 
            if (OnEquipmentChanged != null){
                OnEquipmentChanged.Invoke(null, oldItem); 
            }
        }
    }

    public void UnequipAll(){
        for(int i = 0; i < currentEquipment.Length; i++){
            Unequip(i); 
        }
    }
}
