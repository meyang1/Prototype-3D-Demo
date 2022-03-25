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
    Camera cam;

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
        if(Input.GetMouseButton(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //store what is being clicked on/hit

            if(Physics.Raycast(ray, out hit, 100, movementMask)){ //range to allow clicks and mask
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                
                //Move player to what we hit
                //motor.MoveToPoint(hit.point);
                //Stop focusing any other objects
            }
            motor.MoveToPoint(followObject.transform.position);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCharacter") { 
    
            animator.SetInteger("AnimState", 1); //hit
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
