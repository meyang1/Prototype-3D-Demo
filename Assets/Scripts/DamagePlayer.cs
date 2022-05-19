using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    StaticVariablesCharacter staticVars;
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {  
    }
     
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats playerStatistics = collision.gameObject.GetComponent<PlayerStats>();
            playerStatistics.TakeDamage(damage); 

        }
    } 
}
