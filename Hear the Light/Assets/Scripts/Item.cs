using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new item"; 
    public string desc = "description"; 
    public Sprite icon = null; 
    public ItemType type;

    public virtual void Use(){
        Debug.Log("Using " + name); 
    }

    public void RemoveFromInventory(){
        GameObject.Find("Player").GetComponent<Inventory>().Remove(this); 
    }
}

public enum ItemType { Tool, Ammo, Shield, Projectile, Food, Clothing, Other }