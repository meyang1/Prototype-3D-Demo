using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
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
        //add loot
        Destroy(gameObject);
    }
}
