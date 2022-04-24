using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingBasic : MonoBehaviour
{
    CharacterController characterController;
    StaticVariablesCharacter staticVars;
    private float fixedDeltaTime;
    Animator animator;
    public GameObject menu;
    public GameObject Sword;
    public GameObject TreesTest;
    public GameObject ActualSword;

    public float SwordDelay = 1.0f;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float dashSpeedX = 6.0f;
    public float dashSpeedY = 6.0f;

    public float gravity = 20.0f;
    public bool pressedAttack = false;

    private float canJump = 0f;
    public float timeTillJump = 0f;
    public float timeTillDash = 1f;
    public AudioClip _forwardThrust;
    public AudioClip _sideThrust;
    public AudioClip _doubleThrust;
    public AudioSource _audioSource;
    public Texture2D cursorTextureClick;
    public Texture2D cursorTextureDefault;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        this.fixedDeltaTime = Time.fixedDeltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //speed = staticVars.speed;

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump") && Time.time > canJump)
            {
                moveDirection.y = jumpSpeed;
                canJump = Time.time + timeTillJump;

            }


            if (Input.GetMouseButton(0))
            {
                //keyDown = true;
                //speed = 2.5f;
                Cursor.SetCursor(cursorTextureClick, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(cursorTextureDefault, hotSpot, cursorMode);
            }

            /*if (Input.GetKeyDown(KeyCode.E)&& Time.time > canJump)
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
            }*/


        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        //speed = staticVars.speed;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4f;//3f;
            animator.speed = 1.5f;
        }
        else
        {
            speed = 3f; //2
            animator.speed = 1f;
        }

        if (Input.GetKey(KeyCode.G))
        {
            TreesTest.SetActive(false);
        }
        if (Input.GetKey(KeyCode.H))
        {
            TreesTest.SetActive(true);
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
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Time.time > canJump)
                {
                    moveDirection.y = dashSpeedY;
                    moveDirection.x = dashSpeedX;
                    canJump = Time.time + timeTillDash;
                }
            }
            //transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetInteger("AnimState", 2);
            keyDown = true;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Time.time > canJump)
                {
                    moveDirection.y = dashSpeedY;
                    moveDirection.x = -dashSpeedX;
                    canJump = Time.time + timeTillDash;
                }
            }
            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
