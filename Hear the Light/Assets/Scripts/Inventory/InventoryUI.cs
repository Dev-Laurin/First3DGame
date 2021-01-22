using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; 
    public List<Item> defaultItemIcon = new List<Item>(); 

    InventorySlot[] slots; 
    Inventory inventory; 
    public GameObject inventoryUI; 
    int highlightedSlotIndex; 
    private EquipmentManager equipment; 
    private int currentlyEquipped = -1; 

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>(); 
        equipment = GameObject.Find("Player").GetComponent<EquipmentManager>(); 
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 

        //Don't display yet, not until user opens the menu
        inventoryUI.SetActive(false); 
    }

    public void HighlightInitialSlot(){
        if(currentlyEquipped < 0){
            //highlight initial slot 
            highlightedSlotIndex = 0; 
        } 
        slots[highlightedSlotIndex].HighlightSlot(); 
    }

    public void SetupQuickInventory(int itemType){
        DeHighlightAllSlots(); 

        UpdateUI(itemType); 

        //highlight current equipment
        HighlightCurrentEquipment(System.Enum.GetName(typeof(ItemType), itemType)); 

        HighlightInitialSlot();
    }

    public void HighlightCurrentEquipment(string itemType){ 
        Item equippedItem = equipment.GetEquippedItem(itemType); 

        if(equippedItem == null){
            currentlyEquipped = -1; 
            return; 
        }

        for(int i=1; i<slots.Length; i++){
            if(slots[i].GetItem() == equippedItem){

                slots[i].HighlightSlot(); 
                currentlyEquipped = i; 
                highlightedSlotIndex = currentlyEquipped; 
            }
        }
    }

    public void HighlightRightSlot(){
        if(highlightedSlotIndex + 1 < slots.Length){

            //don't dehighlight currently equipped. 
            if(highlightedSlotIndex != currentlyEquipped){
                slots[highlightedSlotIndex].DeHighlightSlot();
            }      
            
            highlightedSlotIndex += 1;
            slots[highlightedSlotIndex].HighlightSlot(); 
        }  
    }

    public void HighlightLeftSlot(){
        if(highlightedSlotIndex - 1 >= 0){
            //don't dehighlight currently equipped. 
            if(highlightedSlotIndex != currentlyEquipped){
                slots[highlightedSlotIndex].DeHighlightSlot();
            } 
            highlightedSlotIndex -= 1; 
            slots[highlightedSlotIndex].HighlightSlot(); 
        }
    }

    public void DeHighlightAllSlots(){
        for(int i=1; i<slots.Length; i++){
            slots[i].DeHighlightSlot(); 
        }
        highlightedSlotIndex = currentlyEquipped; 
    }

    public void UseItem(){
        slots[highlightedSlotIndex].UseItem(); 
    }

    public void CloseInventory(){
        //equip the highlighted item 
        UseItem(); 
        
        //dehighlight slots 
        DeHighlightAllSlots(); 

        inventoryUI.SetActive(false); 
    }

    void UpdateUI(int itemType){
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
        slots[0].AddItem(defaultItemIcon[itemType]); 
        //skip default icon slot for quick inventory 
        for(int i=1; i<slots.Length; i++){
            Item item = inventory.GetItem(itemType, i - 1); 
            if(item != null){
                slots[i].AddItem(item);
            }
            else{
                slots[i].ClearSlot(); 
            }
        }
    }
}
