using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{

    public bool doorIsOpen;
    public bool doorIsClosed;

    public LayerMask interactivesLayer;
    public Transform door;
    public Collider2D[] interactives;


    private void Start()
    {
        doorIsOpen = false;
        doorIsClosed = true;
    }
    void Update()
    {
        interactives = Physics2D.OverlapCircleAll(transform.position, 1.2f, interactivesLayer);

        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D col in interactives)
            {
                if (col.gameObject.tag == "Door")
                {
                    if (doorIsClosed)
                    {
                        door.position += new Vector3(-0.65f, 0.65f, 0);
                        door.rotation = Quaternion.Euler(0, 0, -90);
                        doorIsOpen = true;
                        doorIsClosed = false;
                    }
                    else
                    {
                        door.position += new Vector3(0.65f, -0.65f, 0);
                        door.rotation = Quaternion.Euler(0, 0, 0);
                        doorIsClosed = true;
                        doorIsOpen = false;
                    }
                }

                if(col.gameObject.tag == "Item")
                {
                    FindObjectOfType<InventoryManager>().ItemList.Add(col.gameObject);
                    col.gameObject.GetComponent<SpriteRenderer>().sortingOrder = -10;
                    FindObjectOfType<InventoryManager>().AddItem();
                }
                else if (col.gameObject.tag == "NPC" && !(col.gameObject.GetComponent<DialogueManager>().inDialogue))
                {
                    col.gameObject.GetComponent<DialogueManager>().StartDialogue(col.gameObject.GetComponent<DialogueManager>().dialogue);
                }
            }
        }
    }
}
