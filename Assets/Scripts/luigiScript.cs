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
    StaticVariablesCharacter staticVars;
    private float fixedDeltaTime;
    Animator animator;
    public GameObject menu;
    public GameObject Sword;
    public GameObject TreesTest;
    public GameObject ActualSword;
    public GameObject FirstPersonView;
    public GameObject jumpButton;
    public GameObject attackButton;
    public GameObject dashButton;




    public float SwordDelay = 1.0f;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float dashSpeedX = 6.0f;
    public float dashSpeedY = 6.0f;

    public float gravity = 20.0f;
    public bool pressedAttack = false;

    private float canJump = 0f;
    public bool firstClick = false;

    public float timeTillJump = 0f ;
    public float timeTillDash = 1f;
    public AudioClip _forwardThrust;
    public AudioClip _sideThrust;
    public AudioClip _doubleThrust;
    public AudioSource _audioSource; 
    public Texture2D cursorTextureClick;
    public Texture2D cursorTextureDefault;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool checkJump = false;
    public bool checkAttack = false;
    public bool checkRun = false;
    public bool checkBag = false;

    private Vector3 moveDirection = Vector3.zero;

    public Joystick joystick;

    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        speed = staticVars.speed;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        this.fixedDeltaTime = Time.fixedDeltaTime;

        _audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        firstClick = true;
        bool keyDown = false;
        if (Input.GetMouseButton(0))// && firstClick == false)
        {
            //StartCoroutine(FirstClick());
            keyDown = true;
        }

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            //speed = staticVars.speed;

           // moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
            Debug.Log("Horizontal");
            Debug.Log(joystick.Horizontal.ToString()); 
            Debug.Log("Vertical");
            Debug.Log(joystick.Vertical.ToString());
            // moveDirection *= speed;
            if (joystick.Horizontal >= .2f)
            {moveDirection *= speed;
            }
            else if(joystick.Horizontal<= -.2f)
            {moveDirection *= speed;
            }
            else
            {
                moveDirection *= speed;
            }

             
            //if (Input.GetButtonDown("Jump") || Input.touchCount == 2 && Time.time > canJump)
            if( Time.time > canJump && checkJump == true)
            {
                moveDirection.y = jumpSpeed;
                canJump = Time.time + timeTillJump; 
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


        if (checkRun && Input.touchCount>1)//Input.GetKey(KeyCode.LeftShift))
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


         
        Cursor.SetCursor(null, hotSpot, cursorMode);
         
        
        if (Input.GetKey(KeyCode.W)|| joystick.Vertical >= .2f)
        {
            animator.SetInteger("AnimState", 0); //Left
            keyDown = true;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        } 
        if (Input.GetKey(KeyCode.S)|| joystick.Vertical <= -.2f)
        {
            animator.SetInteger("AnimState", 0);
            keyDown = true;

            //transform.localRotation = Quaternion.Euler(0, 180, 0);
        } 
        
        if (Input.GetKey(KeyCode.D)|| joystick.Horizontal >= .2f)
        {
            animator.SetInteger("AnimState", 1); //Right
            staticVars.firstPersonAnimator.SetInteger("AnimState", 1);
            keyDown = true;
            if (checkRun)//Input.GetKeyDown(KeyCode.LeftShift))
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
        if (Input.GetKey(KeyCode.A)|| joystick.Horizontal <= -.2f)
        {
            animator.SetInteger("AnimState", 2);
            staticVars.firstPersonAnimator.SetInteger("AnimState", 2);
            keyDown = true;
            if (checkRun)//Input.GetKeyDown(KeyCode.LeftShift))
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
        
        FirstPersonView.SetActive(staticVars.firstPerson);
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SetFirstPerson());
        }

        if (!characterController.isGrounded && checkAttack && firstClick == true)//Input.GetKeyDown(KeyCode.F))
        {
            //StartCoroutine(SwordSlowJump(.1f));
            if (pressedAttack == false)
            {
                Time.timeScale = .4f;
                ActualSword.GetComponent<Animator>().speed = 5;
                pressedAttack = true;
                Debug.Log("Set Pressed Attack to true");
            }
        }
        else if(pressedAttack == true && characterController.isGrounded)
        {
            Time.timeScale = 1f;
            ActualSword.GetComponent<Animator>().speed = 1;
            pressedAttack = false;
            Debug.Log("Set Pressed Attack to false");

        }

        if (staticVars.firstPerson)
        {
            jumpButton.SetActive(false);
            attackButton.SetActive(false);
            dashButton.SetActive(false);
        }
        else
        {
            jumpButton.SetActive(true);
            attackButton.SetActive(true);
            dashButton.SetActive(true);

        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && checkAttack == true && firstClick == true)//Input.GetKeyDown(KeyCode.F))
        {
            Sword.GetComponent<Renderer>().enabled = true;
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 1);
            //_audioSource.clip = _sideThrust;
            //_audioSource.PlayOneShot(_sideThrust, 0.7F);

        }
        else if (Input.GetKey(KeyCode.A) &&  checkAttack == true && firstClick == true)//Input.GetKeyDown(KeyCode.F))
        {
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 2);
            //_audioSource.clip = _doubleThrust;
            //_audioSource.PlayOneShot(_doubleThrust, 0.7F);
        }
        else if (!Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && checkAttack == true && firstClick == true)//Input.GetKeyDown(KeyCode.F))
        {
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 3);
            //_audioSource.clip = _forwardThrust;
            //_audioSource.PlayOneShot(_forwardThrust, 0.7F);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W) && checkAttack == true && firstClick == true)//Input.GetKeyDown(KeyCode.F))
        {
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 1);
            //_audioSource.clip = _sideThrust;
            //_audioSource.PlayOneShot(_sideThrust, 0.7F);
        }
        else
        {
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 0);

            Sword.GetComponent<Renderer>().enabled = true;
        }
        
        if(keyDown == false){
            animator.SetInteger("AnimState", 0);

            staticVars.firstPersonAnimator.SetInteger("AnimState", 0);
        }
        
        //Idle
        
        if(ActualSword.transform.GetChild(0).GetComponent<SlowTimeSword>().hitSomething == true)
        {

            StartCoroutine(SwordSlow(.05f)); 
        }
        //Sword Slow
        
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
        checkAttack = false;
        checkJump = false;
        checkRun = false;
    }
    IEnumerator SetSword(float delay)
    {
        Sword.SetActive(true);
         
        yield return new WaitForSeconds(delay);
        Sword.SetActive(false);
    }
    IEnumerator FirstClick()
    {

        yield return new WaitForSeconds(0f);
        firstClick = true;
    }
    public void FirstPerson()
    {
        StartCoroutine(SetFirstPerson());

    }
    IEnumerator SetFirstPerson()
    {
        staticVars.firstPerson = !staticVars.firstPerson;
        yield return new WaitForSeconds(2f); 
        staticVars.firstPersonCanvas.SetActive(staticVars.firstPerson);
    }
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Partner")
        {
            Debug.Log("We collided with " + collision.gameObject.name);
            collision.gameObject.transform.SetParent(gameObject.transform, true);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Partner")
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            //collision.gameObject.transform.position.SetParent(gameObject.transform.position.true);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Partner")
        {
            Debug.Log("We exit collision with " + collision.gameObject.name);
            collision.gameObject.transform.parent = null;
        }
    }
    */
    IEnumerator SwordSlow(float timeDelay)
    { 
        Time.timeScale = .1f;
        yield return new WaitForSeconds(timeDelay);
        //_audioSource.PlayOneShot(_sideThrust, 0.7F);

        Time.timeScale = 1f;
        ActualSword.transform.GetChild(0).GetComponent<SlowTimeSword>().hitSomething = false;
        
    }
    IEnumerator SwordSlowJump(float timeDelay)
    {

        ActualSword.GetComponent<Animator>().SetInteger("AnimState", 0);
        while (!characterController.isGrounded)
        { 
            ActualSword.GetComponent<Animator>().SetInteger("AnimState", 4);
            ActualSword.GetComponent<Animator>().speed = 10;

            Time.timeScale = .1f;
            yield return null;
        }
        if(characterController.isGrounded)
        {
            Time.timeScale = 1f;
            ActualSword.GetComponent<Animator>().speed = 1;
        }

    }
    public void SetCheckJump()
    {
        checkJump = true; 
    }
    public void SetCheckAttack()
    {
        checkAttack = true;
    }
    public void SetCheckRun()
    {
        checkRun = true;
    }
    public void OpenBag()
    {
        staticVars.SetFirstPerson();
        staticVars.firstPerson = !staticVars.firstPerson;
    }
}