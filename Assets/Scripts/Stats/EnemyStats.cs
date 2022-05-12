using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public Animator ExtraDeathAnimation;
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
        if (ExtraDeathAnimation != null)
            ExtraDeathAnimation.SetInteger("AnimState", 1);
        StartCoroutine(WaitToDie(1.4f));

        //add loot
    }

     

    IEnumerator WaitToDie(float delay)
    {  
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
