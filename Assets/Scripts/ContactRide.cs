using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactRide : MonoBehaviour
{

    public bool canRide = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            canRide = true;
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canRide = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            canRide = false;
        }
    }
}
