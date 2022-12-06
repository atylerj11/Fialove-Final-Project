using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(9);

    private void onEnable() {

        Inventory.OnInvetoryChange += DrawInventory;
    }

    private void onDisable()
    {

        Inventory.OnInvetoryChange -= DrawInventory;
    }
    void ResetInventory() {

        foreach (Transform childTransform in transform) {

            Destroy(childTransform.gameObject);
        
        }
        inventorySlots = new List<InventorySlot>(12);
    
    }

    void DrawInventory(List<InventoryItem> inventory) {

        ResetInventory();
        for (int i = 0; i < inventorySlots.Capacity; i++) {

            CreateInventorySlot();
        }

        for (int i = 0; i < inventory.Count; i++) {

            inventorySlots[i].DrawSlot(inventory[i]);
            
        }
    }

    void CreateInventorySlot() {

        GameObject newSlot = Instantiate(slotPrefab) as GameObject;

        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        newSlotComponent.ClearSlot();

        inventorySlots.Add(newSlotComponent);
    }
}
