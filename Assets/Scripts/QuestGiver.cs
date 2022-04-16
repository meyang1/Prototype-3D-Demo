using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
    StaticVariablesCharacter staticVars;
    public Quest quest;

    //public Player player; 

    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;

    }

    public void OpenQuestWindow()
    {
        staticVars.questWindow.SetActive(true);
        staticVars.questTypeTitleText.text = quest.title;
        staticVars.titleText.text = quest.title;
        staticVars.descriptionText.text = quest.description;
        staticVars.regionText.text = quest.region;
         
        staticVars.conditionsText.text = quest.goalDescription;

        staticVars.levelRequirementText.text = "Level " + quest.levelRequirement.ToString() + " or higher";
        staticVars.experienceText.text = quest.experienceReward.ToString() + " exp";
        staticVars.goldText.text = quest.currencyReward.ToString() + " currency";
        staticVars.quest = quest;
    }
    /*
    public void AcceptQuest()
    {
        staticVars.questWindow.SetActive(false);
        staticVars.quest = quest;
        staticVars.quest.isActive = true;
        //give to player
        LoadLevel(staticVars.quest.sceneIndexRegion);

    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null; //wait until the next frame 
        }
    }*/
}
