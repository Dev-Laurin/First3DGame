﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name; 
    public string desc; 
    public Sprite icon; 
}
