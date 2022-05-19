using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachEnd : MonoBehaviour
{
    public StaticVariablesCharacter staticVars; 


    void OnCollisionEnter(Collision collision)
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        if (collision.gameObject.name == "PlayerCharacter")
        { 
            if (staticVars.quest.isActive)
            {
                staticVars.quest.goal.ReachEnd();
                Debug.Log("Reached the end -- Goal");
                if (staticVars.quest.goal.IsReached())
                {
                    staticVars.increaseExperience(staticVars.quest.experienceReward);
                    staticVars.increaseCurrency(staticVars.quest.currencyReward);
                    staticVars.questCompleteWindow.SetActive(true);
                    staticVars.quest.Complete();
                }
            } 
        }
    }
}
