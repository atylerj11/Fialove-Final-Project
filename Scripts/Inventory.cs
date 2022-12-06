using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static event Action<List<InventoryItem>> OnInvetoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable()
    {

        berryscript.OnFruitCollected += Add;
    }

    private void OnDisable()
    {

        berryscript.OnFruitCollected -= Add;
    }

    public void Add(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            
            Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            OnInvetoryChange?.Invoke(inventory);

        }else{

            InventoryItem newItem = new InventoryItem(itemData);
            itemDictionary.Add(itemData, newItem);
            inventory.Add(newItem);
            
  
            Debug.Log($" Added {item.itemData.displayName} to the inventory for the first time");
            OnInvetoryChange?.Invoke(inventory);
        }
    }
    public void Remove(ItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
                Debug.Log($"{item.itemData.displayName} total stack is now {item.stackSize}");
            }
            OnInvetoryChange?.Invoke(inventory);
        }
    }
}

