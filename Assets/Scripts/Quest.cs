using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //allows unity to serialize the fields and show up in the field

public class Quest   
{
    public bool isActive;

    StaticVariablesCharacter staticVars;
    public string title;
    public string description;
    public string region;
    public int sceneIndexRegion;

    public string goalDescription;

    public int levelRequirement;
    public int experienceReward;
    public int currencyReward;
    public bool questComplete = false;

    public QuestGoal goal;

    public void Complete()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        isActive = false; 
        Debug.Log(title + " was completed!");
        goal = null;
        staticVars.questTypeWindow.SetActive(false);
        //staticVars.currencyAmount += currencyReward;
        //staticVars.increaseExperience(experienceReward);
    }

}
