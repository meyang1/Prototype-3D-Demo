using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTimelineOn : MonoBehaviour
{
    public GameObject timelineThing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            timelineThing.SetActive(false);
        }
        if (Input.GetKey(KeyCode.I))
        {
            timelineThing.SetActive(true);
        }
    }
}
