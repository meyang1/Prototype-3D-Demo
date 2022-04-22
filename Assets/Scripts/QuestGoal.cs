using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal 
{
    public GoalType goalType;
    StaticVariablesCharacter staticVars;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
            staticVars.questTypeProgress.text = staticVars.quest.goal.currentAmount.ToString() + "/" + staticVars.quest.goal.requiredAmount.ToString() + " Enemies";
        }
    }

    public void ItemCollected()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        if (goalType == GoalType.Gathering)
        {
            currentAmount++;
            staticVars.questTypeProgress.text = staticVars.quest.goal.currentAmount.ToString() + "/" + staticVars.quest.goal.requiredAmount.ToString() + " Items";

        }
    }

    public void ReachEnd()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        if (goalType == GoalType.Reach)
        {
            currentAmount++;
            staticVars.questTypeProgress.text = "In Progress";

        }
    }


}

//define different types of goals
public enum GoalType
{
    Kill, //defeat enemies
    Gathering, //gather number of items
    Survive,
    Reach //for certain amount of time
    //Escort, etc.
}