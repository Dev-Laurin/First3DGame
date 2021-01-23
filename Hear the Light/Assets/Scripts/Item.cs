using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "new item"; 
    public string desc = "description"; 
    public Sprite icon = null; 
    public ItemType type;

    private int id; //for inventory only

    public virtual void Use(){
        Debug.Log("Using " + name); 
    }

    public void RemoveFromInventory(){
        GameObject.Find("Player").GetComponent<Inventory>().Remove(this); 
    }

    public void SetID(int ID){
        id = ID; 
    }
}

public enum ItemType { Tool, Ammo, Shield, Projectile, Food, Clothing, Other }