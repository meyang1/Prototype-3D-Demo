using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public event System.Action<int, int> OnHealthChanged;
    public override void Die()
    {
        base.Die();
        staticVars.increaseExperience(20);


        if (staticVars.quest.isActive)
        {
            staticVars.quest.goal.EnemyKilled();
            Debug.Log("Killed one enemy -- Goal");
            if (staticVars.quest.goal.IsReached())
            {
                staticVars.increaseExperience(staticVars.quest.experienceReward);
                staticVars.increaseCurrency(staticVars.quest.currencyReward); 
                staticVars.questCompleteWindow.SetActive(true);
                staticVars.quest.Complete();
            }
        }
        //add ragdoll effect/ death animation

        Animator enemyAnimator = gameObject.GetComponent<Animator>();
        if (enemyAnimator != null)
            enemyAnimator.SetInteger("AnimState", 1);
        StartCoroutine(WaitToDie(1.4f));

        //add loot
    }


    public override void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // set limits to the damage variable;

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            Debug.Log("Current health " + currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die(); //for players, gameover/respawn; for enemies, drop loot and disappear
        }

    }

    IEnumerator WaitToDie(float delay)
    {  
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
