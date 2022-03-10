using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCamera : MonoBehaviour
{
    public GameObject player;
    public float smoothTime = 2;
    public float offSetY = 0.5f;
    public float offSetZ = 0.5f;
    Rigidbody rb;
    Rigidbody cameraRB;
    bool checkCollision = false;
    Vector3 v3; 
    public Camera myCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        cameraRB = this.GetComponent<Rigidbody>();
        v3 = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(player.transform.position.x, player.transform.position.y + offSetY, player.transform.position.z - offSetZ), ref v3, smoothTime);
        
        if (checkCollision==false && myCamera.fieldOfView < 37.95f)
        {
            myCamera.fieldOfView += 1.01f;
        }

    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            checkCollision = true;
            //offSetZ = 4;
            //offSetY = 1; 
            if (myCamera.fieldOfView > 30.5f)
            {
                //ZoomInCamera();
            }
        }
    }
    void OnCollisionStay(Collision collision) { 
        if (collision.gameObject.name == "Cube")
        {
            checkCollision = true;
            //offSetZ = 4;
            //offSetY = 1;
        }
        if (myCamera.fieldOfView > 30.5f)
        { 
            myCamera.fieldOfView -= 1.01f;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        checkCollision = false;

        //offSetZ = 10;
        //offSetY = 2;
        //myCamera.fieldOfView = 37.95f;

    }
    IEnumerator ZoomInCamera()
    {
        yield return new WaitForSeconds(0.1f);
        if (myCamera.fieldOfView > 30.01f)
        {
            myCamera.fieldOfView -= 1.01f; 
        }
    }

}
