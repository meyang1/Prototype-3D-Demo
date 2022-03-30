using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

//[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask movementMask;
    PlayerMotor motor;
    public GameObject followObject;
    public float health = 100; 
    Camera cam;

    public Interactable focus;
    public Interactable defaultFocus;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; // accessing to check whether currently hovering over UI, then exit
        }
        if (Input.GetMouseButton(0) && motor!= null && Input.GetKey(KeyCode.LeftControl))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //store what is being clicked on/hit

            if (Physics.Raycast(ray, out hit, 200, movementMask))
            { //range to allow clicks and mask
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);

                //Move player to what we hit
                motor.MoveToPoint(hit.point);

                //Stop focusing any other objects
                RemoveFocus();
            }
            //motor.MoveToPoint(followObject.transform.position);
        }
         

        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetFocus(defaultFocus);

        }


        //if(health<=0){
        //Destroy(gameObject);
        //
    }

    void SetFocus(Interactable newFocus) {
        if(newFocus != focus)
        {
            //if(focus!=null)
                //focus.OnDefocused();
            focus = newFocus;
            if (motor != null)
            {
                motor.FollowTarget(focus);
            }
        } 

        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefocused();
        focus = null;

        if (motor != null)
            motor.StopFollowingTarget();
    }




    
    
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") { 
    
            animator.SetInteger("AnimState", 1); //hit
        }
        
        if(collision.gameObject.tag == "Cube")
        {
            health -= 10;
            animator.SetInteger("AnimState", 4);
        }

        if(collision.gameObject.tag == "Player")   
        {
            Debug.Log("We collided with " + collision.gameObject.name);
            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") { 
    
            animator.SetInteger("AnimState", 1); //hit
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "Cube") { 
    
            animator.SetInteger("AnimState", 0); //idle
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("We exit collision with " + collision.gameObject.name);
            collision.gameObject.transform.parent = null;
        }
    }
    */
}
