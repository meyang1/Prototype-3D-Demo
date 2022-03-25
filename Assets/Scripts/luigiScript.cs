using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class luigiScript : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public GameObject menu;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private float canJump = 0f;
    public float timeTillJump = 0.25f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump")&& Time.time > canJump)
            {
                moveDirection.y = 7;
                canJump = Time.time + timeTillJump; 
            }
            if (Input.GetKeyDown(KeyCode.E)&& Time.time > canJump)
            {
                moveDirection.y = jumpSpeed;
                moveDirection.x = jumpSpeed;
                canJump = Time.time + .24f; 
            }
            if (Input.GetKeyDown(KeyCode.Q)&& Time.time > canJump)
            {
                moveDirection.y = jumpSpeed;
                moveDirection.x = -jumpSpeed;
                canJump = Time.time + .24f; 
            }

        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 3f;
        }
        else{
            speed = 2f;
        }

        bool keyDown = false;
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("AnimState", 0); //Left
            keyDown = true;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("AnimState", 0);
            keyDown = true;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        } 
        
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("AnimState", 1); //Right
            keyDown = true;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 2);
            keyDown = true;
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        
        if(keyDown == false){
            animator.SetInteger("AnimState", 0);
        }
        
        //Idle
        

        
        bool menuOpen = false;
        //Menu
        if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == false){
            menu.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && menuOpen == false){      
            menuOpen = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuOpen == true){
            menu.SetActive(false);
        }
        else if(Input.GetKeyUp(KeyCode.Escape) && menuOpen == false){
            menuOpen = false;
        }
    }
}