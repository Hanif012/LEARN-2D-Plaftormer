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
    public TMP_Text continueButton;
    public Queue<string> sentences;
    public bool inDialogue;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return)||Input.GetMouseButtonDown(0)){
            DisplayNextSentence();
        }
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        animator.SetBool("isOpen",true);
        inDialogue = true;
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
        continueButton.text = "";
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // Debug.Log(sentence);
    }

    public void EndDialogue(){
        animator.SetBool("isOpen",false);
        inDialogue = false;
        continueButton.text = "";
        // Debug.Log("End of convo");
        return;
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        continueButton.text = ">Continue";
    }
}
