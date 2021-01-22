using UnityEngine;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour
{

    public Image icon; 
    public Image background; 
    Item item; 

    public bool AddItem(Item newItem){
        item = newItem; 
        icon.sprite = item.icon; 
        icon.enabled = true; 

        if(item == null){
            icon.enabled = false; 
            return false; 
        }
        return true; 
    }

    public void ClearSlot(){
        item = null; 
        icon.sprite = null; 
        icon.enabled = false; 
    }

    public void UseItem(){
        if(item != null){
            item.Use(); 
        }
    }
    
    public Item GetItem(){
        return item; 
    }

    public void HighlightSlot(){
        background.color = new Color32(30,144,255,255); //rgb
    }

    public void DeHighlightSlot(){
        background.color = new Color32(142, 142, 142, 255); 
    }
}
