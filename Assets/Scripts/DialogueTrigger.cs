using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public Dialogue dialogue; 

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
        if(collision.gameObject.tag=="Player" && Input.GetKey(KeyCode.Space)){
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
            animator.SetInteger("AnimState", 0);
        }
    }
    void OnTriggerExit(Collider collision){
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        animator.SetInteger("AnimState", 0);

    }
}   
