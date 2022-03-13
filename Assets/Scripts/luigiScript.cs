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

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

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

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 4f;
        }
        else{
            speed = 3f;
        }


        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetInteger("AnimState", 1); //Left
            //transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 1);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            animator.SetInteger("AnimState", 0); //Idle
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetInteger("AnimState", 1); //Left
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetInteger("AnimState", 1);
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {  
        }
        else
        {
            animator.SetInteger("AnimState", 0);
        }
    }
}