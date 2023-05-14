using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Dialogue dialogue;
    public Queue<string> sentences;

    public GameObject DialogueBox;
    public GameObject enemy;
    public GameObject player;

    public bool inDialogue = false;
    public bool fight;
    public bool isEnemy;

    private void Start()
    {
        sentences = new Queue<string>();
        FindObjectOfType<InventoryManager>().canOpenInv = true;
    }
    private void Update()
    {
        if (inDialogue && Input.GetKeyDown(KeyCode.Space))
            DisplayNextSentence();
        if (fight)
        {
            player.GetComponent<Player>().SavePlayer();
            enemy.GetComponent<SetCustomFieldSize>().LoadCustom();
            fight = false;
        }
            
    }

    public void StartDialogue(Dialogue dialogue)
    {
        FindObjectOfType<Movement>().canWalk = false;
        FindObjectOfType<InventoryManager>().canOpenInv = false;
        FindObjectOfType<InventoryManager>().Inventory.gameObject.SetActive(false);
        DialogueBox.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        inDialogue = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Debug.Log("null");
            inDialogue = false;
            EndDialogue();
        }
        else
        {
            string sentence = sentences.Dequeue();
            Debug.Log(sentences.Count);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    { 
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }    
    }
        
    void EndDialogue()
    {
        sentences.Clear();
        DialogueBox.SetActive(false);
        FindObjectOfType<InventoryManager>().canOpenInv = true;
        FindObjectOfType<Movement>().canWalk = true;
        if (isEnemy)
            fight = true;
    }
}
