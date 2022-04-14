using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariablesCharacter : MonoBehaviour
{

    public static StaticVariablesCharacter Eyevon;
    void Awake()
    {
        if (Eyevon == null)
        {
            Eyevon = this;
        }
        else
        {
            Destroy(this.gameObject);
        } // when start, setting equal to this particular component (can access by Inventory.instance)
        DontDestroyOnLoad(this.gameObject);
    }


    public int maxHealth=100;
    public int currentHealth = 100;
    public float attack=10;
    public float speed=3;
    public float jumpSpeed=8;


    public void increaseHealth(int healthIncrease)
    {
        maxHealth += healthIncrease;
    }

    public void increaseAttack(float attackIncrease)
    {
        attack += attackIncrease;
    }

    public void increaseSpeed(float speedIncrease)
    {
        speed += speedIncrease;
    }

    public void increaseJumpSpeed(float jSpeedIncrease)
    {
        jumpSpeed += jSpeedIncrease;
    }
}
