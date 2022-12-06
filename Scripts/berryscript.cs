using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class berryscript : MonoBehaviour, ICollectible
{
    public static event HandleFruit OnFruitCollected;
    public delegate void HandleFruit(ItemData itemData);
    public ItemData FruitData;
    // Start is called before the first frame update
    public void Collect() {

        Destroy(gameObject);
        OnFruitCollected?.Invoke(FruitData);
        
    }
}
