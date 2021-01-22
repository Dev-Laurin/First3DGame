using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<List<Item>> inventory; 

    public List<int> space; 

    public delegate void OnItemChanged(); 
    public OnItemChanged onItemChangedCallback; 

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<List<Item>>(); 
        for(int i=0; i<System.Enum.GetNames(typeof(ItemType)).Length; i++){
            inventory.Add(new List<Item>()); 
        }
    }

    public bool AddItem(Item item){

        if(inventory[(int)item.type].Count >= space[(int)item.type]){
            return false; 
        }
        inventory[(int)item.type].Add(item); 
        
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 

        return true; 
    }

    public Item GetItem(int listIndex, int index){
        if(inventory[listIndex].Count > index && index >= 0){
            return inventory[listIndex][index];
        }
        return null; 
    }

    public void RemoveItem(int listIndex, int index){
        inventory[listIndex].RemoveAt(index); 
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
    }

    public void Remove(Item item){
        inventory[(int)item.type].Remove(item); 
    }

    //which category of items are we swapping? Which list? 
    public void SwapItems(int listIndex, int a, int b){
        Item temp = inventory[listIndex][a]; 
        inventory[listIndex][a] = inventory[listIndex][b]; 
        inventory[listIndex][b] = temp; 

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
    }

    public void MoveItem(int listIndex, int index, int newIndex){
        if(inventory[listIndex][newIndex] != null){
            //item already exists there, swap it 
            SwapItems(listIndex, index, newIndex); 
        }
        else{
            //item doesn't exist there, just move it 
            inventory[listIndex][newIndex] = inventory[listIndex][index]; 
            inventory[listIndex][index] = null; 
        }

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
    }
}
