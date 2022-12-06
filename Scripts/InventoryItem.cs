using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int stackSize;
    public static float num;

    public InventoryItem(ItemData item)
    {
        itemData=item;
        AddToStack();
    }

    public void AddToStack()
    {
        num++;
        stackSize++;
    }
    public void RemoveFromStack()
    {
        num--;
        stackSize--;
    }
}
