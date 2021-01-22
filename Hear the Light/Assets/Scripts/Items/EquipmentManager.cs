using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public delegate void OnEquipmentChange(Equipment newItem); 
    public OnEquipmentChange OnEquipmentChanged; 

    public Equipment[] currentEquipment; 

    void Start(){
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

        //callbacks 
        if (OnEquipmentChanged != null){
            OnEquipmentChanged.Invoke(newItem); 
        }

        currentEquipment[slotIndex] = newItem; 
    }

    public void Unequip(int slotIndex){
        if(currentEquipment[slotIndex] != null){

            currentEquipment[slotIndex] = null; 

            //callbacks 
            if (OnEquipmentChanged != null){
                OnEquipmentChanged.Invoke(null); 
            }
        }
    }

    public void UnequipItemByTypeName(string type){
        Unequip((int)System.Enum.Parse(typeof(EquipmentSlot), type)); 
    }

    public void UnequipAll(){
        for(int i = 0; i < currentEquipment.Length; i++){
            Unequip(i); 
        }
    }
}
