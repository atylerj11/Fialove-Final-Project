using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI Labeltext;
    public TextMeshProUGUI StackSize;

    public void ClearSlot() {

        icon.enabled = false;
        Labeltext.enabled = false;
        StackSize.enabled = false;
    }

    public void DrawSlot(InventoryItem item) {

        if (item == null) {
            ClearSlot();
            return;
        
        }

        icon.enabled = true;
        Labeltext.enabled = true;
        StackSize.enabled = true;

        icon.sprite = item.itemData.icon;
        Labeltext.text = item.itemData.displayName;
        StackSize.text = item.stackSize.ToString();

    }
}
