using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMFreeLookChange : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineFreeLook cam;

    public void changeFarClipPlane(float changeValue){
        cam.m_Lens.FarClipPlane = changeValue;
    }
}
