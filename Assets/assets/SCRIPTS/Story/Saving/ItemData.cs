using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public float[] InventorySize;

    public bool inInventory;
    public ItemData(Item Item)
    {
        InventorySize = new float[3];
        InventorySize[0] = Item.transform.position.x;
        InventorySize[1] = Item.transform.position.y;
        InventorySize[2] = Item.transform.position.z;
    }
}
