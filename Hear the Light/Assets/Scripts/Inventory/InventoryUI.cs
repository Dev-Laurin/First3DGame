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
    private int currentInventorySize = 0; 
    private int offset = 0; //the index offset of our inventory compared to our UI
    private int itemListType = -1; 

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
        itemListType = itemType; 

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
        Debug.Log("Moving Right. Carousel value: " + (currentInventorySize > offset + slots.Length && highlightedSlotIndex + 1 > slots.Length)); 
        Debug.Log("Inventory size > offset + slot length (qualifier): " + (currentInventorySize > offset + slots.Length)); 
        Debug.Log("slot + 1 > slot length: " + (highlightedSlotIndex + 1 > slots.Length)); 
        Debug.Log("offset: " + offset); 
        Debug.Log(highlightedSlotIndex + 1 ); 

        if(highlightedSlotIndex + 1 < slots.Length){

            //don't dehighlight currently equipped. 
            if(highlightedSlotIndex != currentlyEquipped){
                slots[highlightedSlotIndex].DeHighlightSlot();
            }     
            
            highlightedSlotIndex += 1;
            slots[highlightedSlotIndex].HighlightSlot(); 
        }  
        //if slots are filled but we are still going right (carousel)
        else if(currentInventorySize > offset + slots.Length && highlightedSlotIndex + 1 > (slots.Length - 1) ){
            //re-fill slots with 1 new item showing on the right 
            Debug.Log("Moving Carousel Right"); 
            offset += 1; 
            UpdateUICarousel(); 
        }
    }

    public void HighlightLeftSlot(){
        Debug.Log("Moving Left. Carousel value: " + (currentInventorySize > slots.Length && 0 < offset)); 
        Debug.Log("offset: " + offset); 
        if(highlightedSlotIndex - 1 >= 0){
            //don't dehighlight currently equipped. 
            if(highlightedSlotIndex != currentlyEquipped){
                slots[highlightedSlotIndex].DeHighlightSlot();
            } 
            highlightedSlotIndex -= 1; 
            slots[highlightedSlotIndex].HighlightSlot(); 
        }
        //moving left (carousel)
        else if(currentInventorySize > slots.Length && offset > 0){
            Debug.Log("Moving Carousel Left"); 
            offset -= 1; 
            UpdateUICarousel(); 
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

    void UpdateUICarousel(){
        int startingIndex = 0; 

        if(offset == 0){ //moving leftwards to the very end, add the default icon 
            Debug.Log("Placing default Item icon"); 
            startingIndex = 1; 
            slots[0].AddItem(defaultItemIcon[itemListType]);
        }
        for(int i=startingIndex; i<slots.Length; i++){
            Item item = inventory.GetItem(itemListType, i + offset); 
            if(item != null){
                slots[i].AddItem(item);
            }
            else if(i == 0){ //add the back slot 
                 
            }
        }
    }

    void UpdateUI(int itemType){
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
        slots[0].AddItem(defaultItemIcon[itemType]); 

        //for the carousel 
        currentInventorySize = inventory.GetSize(itemType); 

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
