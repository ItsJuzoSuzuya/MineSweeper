using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Vector3 InventorySize;

    public GameObject Combinable;
    public GameObject newObject;

    public bool inInventory;
    public void LoadInInventory()
    {
        this.transform.localScale = new Vector3(InventorySize.x,InventorySize.y,0);
    }
}
