using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool isInteractable;
    DialogueManager dialogueManager;

    void Start(){
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue(){
        // Debug.Log("Dialogue Triggered");
        dialogueManager.StartDialogue(dialogue);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Z) && isInteractable&&dialogueManager.inDialogue == false){
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInteractable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInteractable = false;
    }
}
