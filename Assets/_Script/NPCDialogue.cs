﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{
    public string npcName;
    public string[] npcDialogueLines;
    public Sprite npcSprite;

    private DialogueManager dialogueManager;
    private bool playerInTheZone;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTheZone && Input.GetKeyDown(KeyCode.U))
        {
            string[] finalDialogues = new string[npcDialogueLines.Length];
            int i = 0;

            foreach(string line in npcDialogueLines)
            {
                finalDialogues[i++] = (npcName != null ? npcName + "\n" : "") + line;
            }

            

            if (npcSprite != null)
            {
                dialogueManager.ShowDialogue(finalDialogues, npcSprite);
            } else
            {
                dialogueManager.ShowDialogue(finalDialogues);
            }
            
            if(gameObject.GetComponentInParent<NPCMovement>() != null)
            {
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerInTheZone = false;
        }
    }
}
