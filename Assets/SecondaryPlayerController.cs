using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

//[RequireComponent(typeof(PlayerMotor))]
public class SecondaryPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask movementMask;
    PlayerMotor motor;
    public GameObject followObject;
    string hitName = "";
    public float health = 100;
    Camera cam;

    public Interactable focus;
    Transform target; 
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
        /*if (Input.GetMouseButton(1) && motor != null )
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //store what is being clicked on/hit

            if (Physics.Raycast(ray, out hit, 200, movementMask))
            { 
                motor.MoveToPoint(hit.point);
                RemoveFocus2();
            }
        }*/
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                hitName = hit.collider.name;
                //if we did set it as focus
                if (interactable != null)
                {
                    SetFocus2(interactable);

                    motor.MoveToPoint(hit.point);
                }
                else
                {
                    SetFocus2(defaultFocus);
                }

            }

        }
        else
        {
            if (hitName == "PlayerCharacter" || hitName == "" || focus == null)
            {
                SetFocus2(defaultFocus);
            } 
        }


        //if(health<=0){
        //Destroy(gameObject);
        //
    }
    void FaceTarget1()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void SetFocus2(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            //if(focus!=null)
            //focus.OnDefocused();
            focus = newFocus;
            if (motor != null)
            {
                motor.FollowTarget(focus);
                target = focus.interactionTransform;
                FaceTarget1();
            }
        }

        newFocus.OnFocusedP2(transform);
    }
    void RemoveFocus2()
    {
        if (focus != null)
            focus.OnDefocusedP2();
        focus = null;

        if (motor != null)
            motor.StopFollowingTarget();
    }


}
