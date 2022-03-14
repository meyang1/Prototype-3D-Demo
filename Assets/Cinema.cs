using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class Cinema : MonoBehaviour {
    
    private CinemachineFreeLook cam;
    void Start(){
        CinemachineCore.GetInputAxis = GetAxisCustom;
        cam = GetComponent<CinemachineFreeLook>();
    }
    void Update()
    {
        //if (Input.GetAxis("CameraRecentre") == 1)
        
        if (Input.GetKey(KeyCode.E))
        {
            //cam.m_RecenterToTargetHeading.m_enabled = true;
        }
        else
        {
            //cam.m_RecenterToTargetHeading.m_enabled = false;
        }
    }
    public float GetAxisCustom(string axisName){
        if(axisName == "Mouse X"){
            if (Input.GetMouseButton(1)){
                return UnityEngine.Input.GetAxis("Mouse X");
            } else{
                return 0;
            }
        }
        else if (axisName == "Mouse Y"){
            if (Input.GetMouseButton(1)){
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else{
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}