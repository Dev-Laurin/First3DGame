﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot; 

    public int armorModifier; 
    public int damageModifier; 
    
    public override void Use(){
        base.Use(); 

        //Equip the Item 
        GameObject.Find("Player").GetComponent<EquipmentManager>().Equip(this); 
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Tool, Projectile, Ammo, Shield, Feet}
