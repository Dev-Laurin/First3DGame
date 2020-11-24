using UnityEngine;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour
{

    public Image icon; 
    Item item; 

    public void AddItem(Item newItem){
        item = newItem; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
