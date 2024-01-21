using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Animator animator;
    bool isInteractable;

    // Update is called once per frame
    void Update()
    {
        // if(isInteractable){
        //     Debug.Log("Press Z to teleport");
        // }
        
        if(Input.GetKeyDown(KeyCode.Z) && isInteractable){
            // Debug.Log("Teleporting");
            StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex+1));
        }        
    }

    IEnumerator Transition(int index){
        animator.SetTrigger("Transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
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
