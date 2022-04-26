using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveByTouch : MonoBehaviour
{
     
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); //index of the touch in 0
            //touch.position // coordinates
            //touch.phase // began, ended, moved, stationary, canceled
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = -touchPosition.z;
            transform.position = touchPosition;
        }   
    }
}
