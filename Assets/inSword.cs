using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inSword : MonoBehaviour
{
    public GameObject swordSpriteThing;
    public GameObject full;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            swordSpriteThing.SetActive(true);
            full.SetActive(true);
        }
    }
}
