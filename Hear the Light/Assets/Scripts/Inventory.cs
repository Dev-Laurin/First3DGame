using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items; 
    public int size; 

    // Start is called before the first frame update
    void Start()
    {
        //Load items from save TODO 
        items = new List<Item>(); 
        //populate with nulls in the beginning
        for(int i=0; i<size; i++){
            items.Add(null); 
        }
    }

    public bool AddItem(Item item){
        //find first null item and replace it
        bool slotFound = false; 
        for(int i=0; i<items.Count; i++){
            if(items[i] == null){
                items[i] = item; 
                slotFound = true; 
            }
        }
        if(!slotFound){
            //there are no empty slots 
            return false; 
        }
        return true; 
    }

    public void RemoveItem(int index){
        items.RemoveAt(index); 
    }

    public void SwapItems(int a, int b){
        Item temp = items[a]; 
        items[a] = items[b]; 
        items[b] = temp; 
    }

    public void MoveItem(int index, int newIndex){
        if(items[newIndex] != null){
            //item already exists there, swap it 
            SwapItems(index, newIndex); 
        }
        else{
            //item doesn't exist there, just move it 
            items[newIndex] = items[index]; 
            items[index] = null; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
