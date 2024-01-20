using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TMP_Text nameText;
    public  TMP_Text dialogueText;
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        animator.SetBool("isOpen",true);
        // Debug.Log("Starting conversation with " + dialogue.name);
        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // Debug.Log(sentence);
    }

    public void EndDialogue(){
        animator.SetBool("isOpen",false);
        // Debug.Log("End of convo");
        return;
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
