using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    public Collider2D[] targetedItem;
    public GameObject selectedObject;

    Vector3 offset;
    void Update()
    {
        if (FindObjectOfType<InventoryManager>().Inventory.gameObject.activeInHierarchy)
        { 
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //if (Physics2D.OverlapPoint(mousePosition).gameObject.CompareTag("Item"))
                targetedItem = Physics2D.OverlapPointAll(mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (targetedItem[0].gameObject.tag == "Item")
                {
                    selectedObject = targetedItem[0].transform.gameObject;
                    offset = selectedObject.transform.position - mousePosition;
                }
            }
            if (selectedObject)
            {
                selectedObject.transform.position = mousePosition + offset;
            }
            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                if (targetedItem.Length == 2)
                {
                    if (selectedObject.GetComponent<Item>().Combinable != null && targetedItem[1].gameObject.name == selectedObject.GetComponent<Item>().Combinable.name + "(Clone)" )
                    {
                        FindObjectOfType<InventoryManager>().ItemList.Add(selectedObject.GetComponent<Item>().newObject);
                        for (int i = 0; i < FindObjectOfType<InventoryManager>().Slot.Length; i++)
                        {
                            if (targetedItem[1] == FindObjectOfType<InventoryManager>().Slot[i].GetComponentInChildren<BoxCollider2D>())
                                FindObjectOfType<InventoryManager>().isFull[i] = false;
                            if (targetedItem[0] == FindObjectOfType<InventoryManager>().Slot[i].GetComponentInChildren<BoxCollider2D>())
                                FindObjectOfType<InventoryManager>().isFull[i] = false;
                        }
                        for (int i = 0; i < FindObjectOfType<InventoryManager>().Slot.Length; i++)
                        {
                            if (FindObjectOfType<InventoryManager>().isFull[i])
                                FindObjectOfType<InventoryManager>().ItemList.Add(FindObjectOfType<InventoryManager>().Slot[i]);
                        }
                        DestroyImmediate(targetedItem[1].gameObject, true);
                        DestroyImmediate(selectedObject.gameObject, true);
                        FindObjectOfType<InventoryManager>().AddItem();
                        } else {
                        selectedObject.transform.localPosition = new Vector3(0, 0, 0);
                        selectedObject = null;
                    }
                }else {
                    selectedObject.transform.localPosition = new Vector3(0, 0, 0);
                    selectedObject = null;
                }
            }
        }
    }
}
