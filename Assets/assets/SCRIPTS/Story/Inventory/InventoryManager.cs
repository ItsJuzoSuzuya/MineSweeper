using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Canvas Inventory;

    public GameObject[] Slot;
    public List<GameObject> ItemList;

    public bool[] isFull;
    public bool isOpen = false;
    public bool inInventory;
    public bool canOpenInv = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isOpen && canOpenInv)
            {
                isOpen = true;
                Inventory.gameObject.SetActive(true);
                FindObjectOfType<Movement>().canWalk = false;
            }
            else if (canOpenInv)
            {
                isOpen = false;
                Inventory.gameObject.SetActive(false);
                FindObjectOfType<Movement>().canWalk = true;
            }
        }
    }

    public void AddItem()
    {
        foreach (GameObject items in ItemList)
        {
            for (int i = 0; i < Slot.Length; i++)
            {
                if (!isFull[i]) 
                {
                    items.GetComponent<Item>().inInventory = true;
                    isFull[i] = true;
                    items.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 100;
                    items.transform.position = new Vector3(0, 0, 0);
                    Instantiate(items, Slot[i].transform, false).GetComponent<Item>().LoadInInventory();
                    ItemList.Remove(items);
                    DestroyImmediate(items, true);
                    break;
                }
            }
        }
    }
}
