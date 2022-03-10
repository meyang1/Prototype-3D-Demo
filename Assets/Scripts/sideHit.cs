using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
            this.GetComponent<AudioSource>().Play();
    }

}
