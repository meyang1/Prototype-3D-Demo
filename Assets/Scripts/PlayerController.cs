using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask movementMask;
    PlayerMotor motor;
    public GameObject followObject;
    public float health = 100; 
    Camera cam;

    public Interactable focus;

    Animator animator;
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //store what is being clicked on/hit

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            { //range to allow clicks and mask
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //Move player to what we hit
                motor.MoveToPoint(hit.point);

                //Stop focusing any other objects
                RemoveFocus();
            }
            //motor.MoveToPoint(followObject.transform.position);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                //if we did set it as focus
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
      

        //if(health<=0){
            //Destroy(gameObject);
        //
    }

    void SetFocus(Interactable newFocus) {
        if(newFocus != focus)
        {
            if(focus!=null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(focus);
        } 

        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }






    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCharacter") { 
    
            animator.SetInteger("AnimState", 1); //hit
        }
        if(collision.gameObject.name == "SwordCube"){
            health -= 10;
            animator.SetInteger("AnimState", 4);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCharacter") { 
    
            animator.SetInteger("AnimState", 1); //hit
        }
    }
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.name == "PlayerCharacter") { 
    
            animator.SetInteger("AnimState", 0); //idle
        }
    }
    
}
