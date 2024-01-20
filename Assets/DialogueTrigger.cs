using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    bool isInteractable;

    public void TriggerDialogue(){
        // Debug.Log("Dialogue Triggered");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Z) && isInteractable){
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
