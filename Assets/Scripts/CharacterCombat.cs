using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f; // can make a character stat later!
    public float attackDelay = .6f;
    private float attackCooldown = 0f;

    //callback method for animation
    public event System.Action OnAttack; //create delegate with void return and no arguments

    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }
    void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if(OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed; //greater attack speed = less cooldown
        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());
    }
}
