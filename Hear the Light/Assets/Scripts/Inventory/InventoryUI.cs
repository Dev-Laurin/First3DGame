using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; 
    InventorySlot[] slots; 
    Inventory inventory; 

    // Start is called before the first frame update
    void Start()
    {
       inventory = GameObject.Find("Player").GetComponent<Inventory>(); 
       inventory.onItemChangedCallback += UpdateUI; 

       slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI(){
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        for(int i=0; i<slots.Length; i++){
            if(i < inventory.items.Count){
                slots[i].AddItem(inventory.items[i]); 
            }
            else{
                slots[i].ClearSlot(); 
            }
        }
    }
}
