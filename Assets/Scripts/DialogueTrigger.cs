using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.name == "PlayerCharacter")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}   
