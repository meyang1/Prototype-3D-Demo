using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; 
    public Transform interactionTransform;

    bool isFocus1 = false;
    bool isFocus2 = false;
    public Transform player;
    public Transform player2;

    public bool hasInteracted = false; //check so only debug outputs once

    public virtual void Interact() // a virtual method --> able to be derived for inherited children so not uniform for every class
    {
        //this method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocus1 && !hasInteracted)
        {
            float distance1 = Vector3.Distance(player.position, interactionTransform.position); //checks distance b/w 2 points
            if (distance1<= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }

        if(isFocus2 && !hasInteracted)
        {

            float distance2 = Vector3.Distance(player2.position, interactionTransform.position);
            if (distance2 <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    } 

    public void OnFocused(Transform playerTransform)
    {
        isFocus1 = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus1 = false;
        player = null;
        hasInteracted = false;
    }


    public void OnFocusedP2(Transform playerTransform2)
    {
        isFocus2 = true;
        player2 = playerTransform2;
        hasInteracted = false;
    }

    public void OnDefocusedP2()
    {
        isFocus2 = false;
        player2 = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform; //so auto selects own transform
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius); //current position, radius
    }

     
}
