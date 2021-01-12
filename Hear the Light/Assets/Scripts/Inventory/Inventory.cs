using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items; 
    public int space; 

    public delegate void OnItemChanged(); 
    public OnItemChanged onItemChangedCallback; 

    // Start is called before the first frame update
    void Start()
    {
        //Load items from save TODO 
        items = new List<Item>(); 
    }

    public bool AddItem(Item item){

        if(items.Count >= space){
            return false; 
        }
        items.Add(item); 
        
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 

        return true; 
    }

    public void RemoveItem(int index){
        items.RemoveAt(index); 
        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
    }

    public void Remove(Item item){
        items.Remove(item); 
    }

    public void SwapItems(int a, int b){
        Item temp = items[a]; 
        items[a] = items[b]; 
        items[b] = temp; 

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
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

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); 
    }
}
