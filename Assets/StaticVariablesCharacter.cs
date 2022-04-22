using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int experienceAmount = 0
    public int experienceAmountNeeded = 100;
    public int characterLevel = 1;
    public int currencyAmount = 0;
    public int defense = 10;

    public GameObject fadeToBlack;

    public GameObject questWindow;
    public GameObject questCompleteWindow;
    public GameObject questTypeWindow;
    public Text titleText;
    public Text levelRequirementText;
    public Text descriptionText;
    public Text regionText;
    public Text conditionsText;
    public Text experienceText;
    public Text goldText;


    public Quest quest;

     
    public Text questTypeTitleText;
    public Text questTypeProgress;

    public GameObject levelUpCanvas;
    public GameObject levelLowCanvas;


    public Text levelText;
    public Text attackText;
    public Text speedText;
    public Text defenseText;

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
    
    public void increaseExperience(int expIncrease)
    {
        experienceAmount += expIncrease;
        levelUpCanvas.SetActive(false);
        if (experienceAmount >= experienceAmountNeeded)
        {
            characterLevel++;
            //experienceAmount = 0;
            //experienceAmountNeeded = experienceAmountNeeded * 5 / 4;
            levelText.text = characterLevel.ToString(); 
            //maxHealth = maxHealth * 5/4; 
            currentHealth = maxHealth;
            StartCoroutine(SetCanvasTrue()); 
        }
    }
    public void increaseCurrency(int currencyIncrease)
    {
        currencyAmount += currencyIncrease; 
    }

    public void AcceptQuest()
    {
        questCompleteWindow.SetActive(false);
        /*if (characterLevel < quest.goal.levelRequirement)
        {

        }
        else
        {*/
            questTypeTitleText.text = quest.title;

            if (quest.goal.goalType == GoalType.Kill)
            {
                questTypeProgress.text = quest.goal.currentAmount.ToString() + "/" + quest.goal.requiredAmount.ToString() + " Enemies";
            }
            else if (quest.goal.goalType == GoalType.Gathering)
            {
                questTypeProgress.text = quest.goal.currentAmount.ToString() + "/" + quest.goal.requiredAmount.ToString() + " Items";
            }
            //else if(quest.goal.goalType == GoalType.Reach)
            else
            {
                questTypeProgress.text = "None";
            }
            questTypeWindow.SetActive(true);
            questWindow.SetActive(false);
            quest.isActive = true;
            //give to player
            LoadLevel(quest.sceneIndexRegion);
       // }

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
    }
    IEnumerator SetCanvasTrue()
    {
        levelUpCanvas.SetActive(true);
        yield return new WaitForSeconds(185);
        levelUpCanvas.SetActive(false);
    }

    IEnumerator SetErrorMessageTrue()
    {
        levelUpCanvas.SetActive(true);
        yield return new WaitForSeconds(185);
        levelUpCanvas.SetActive(false);
    }

    public void CancelQuest()
    {
    } 
}
