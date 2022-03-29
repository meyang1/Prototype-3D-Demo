using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public Dialogue dialogue;
    bool dialogueStarted = false;
    private float canRun = 0f;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter(Collider collision)
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        if(collision.gameObject.tag=="Player"){
            animator.SetInteger("AnimState", 1);
        }      
    }
    void OnTriggerStay(Collider collision){
        if(collision.gameObject.tag=="Player" && Input.GetKey(KeyCode.Space) && dialogueStarted==false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
            animator.SetInteger("AnimState", 0);
            dialogueStarted = true;
        }
        if (collision.gameObject.tag == "Player" && dialogueStarted == true)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > canRun)
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                canRun = Time.time + 0.3f;

            } 
        }
    }
    /*
    IEnumerator NextSentence()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }*/
    void OnTriggerExit(Collider collision){
        if (collision.gameObject.tag == "Player")
        {
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
            animator.SetInteger("AnimState", 0);
            FindObjectOfType<DialogueManager>().EndDialogue();
            dialogueStarted = false;
        }


    }
}   
