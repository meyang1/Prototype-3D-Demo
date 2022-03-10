using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    
    public float lifeRemaining;
    float lifeStart;
    float lifeDecrease;
    SpriteRenderer sr; 

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        lifeRemaining = 3;
        lifeDecrease = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision character)
    {
        lifeRemaining -= lifeDecrease;
        if (lifeRemaining < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            print(sr.color); 
        }
    }

   
}
