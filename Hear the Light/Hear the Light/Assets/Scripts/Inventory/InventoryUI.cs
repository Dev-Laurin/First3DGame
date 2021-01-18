using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; 
    public Item defaultWeaponIcon; 
    public Item defaultShieldIcon; 
    public Item defaultBowIcon; 
    public Item defaultArrowIcon; 

    InventorySlot[] slots; 
    Inventory inventory; 
    public GameObject inventoryUI; 
    int highlightedSlotIndex; 

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>(); 
        inventory.onItemChangedCallback += UpdateUI; 

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 

        //Don't display yet, not until user opens the menu
        inventoryUI.SetActive(false); 
    }

    public void SetupWeaponQuickInventory(){
        slots[0].AddItem(defaultWeaponIcon); 

        //highlight initial slot 
        highlightedSlotIndex = 0; 
        slots[highlightedSlotIndex].HighlightSlot(); 
    }

    public void HighlightRightSlot(){
        if(highlightedSlotIndex + 1 < slots.Length){      
            slots[highlightedSlotIndex].DeHighlightSlot();
            highlightedSlotIndex += 1;
            slots[highlightedSlotIndex].HighlightSlot(); 
        }  
    }

    public void HighlightLeftSlot(){
        if(highlightedSlotIndex - 1 >= 0){
            slots[highlightedSlotIndex].DeHighlightSlot();
            highlightedSlotIndex -= 1; 
            slots[highlightedSlotIndex].HighlightSlot(); 
        }
    }

    void UpdateUI(){
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 

        //skip default icon slot for quick inventory 
        for(int i=1; i<slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]); 
            }
            else{
                slots[i].ClearSlot(); 
            }
        }
    }
}
