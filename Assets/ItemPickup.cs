using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    public Item item;
    public GameObject gameObjectItem;
    public Light myLight;
    public Text m_MyText;
    public static int numberHeld = 0;
    public StaticVariablesCharacter staticVars;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        Debug.Log("Picking up " + item.name);

        //add to inventory //Inventory.instance.Add(item); 
        var picked = gameObject.GetComponent<ItemContainer>();

        bool wasPickedUp = Inventory.instance.Add(gameObject.GetComponent<ItemContainer>().Data);

        if (wasPickedUp)
        {
            if (staticVars.quest.isActive)
            {
                staticVars.quest.goal.ItemCollected();
                Debug.Log("Received one item -- Goal");
                if (staticVars.quest.goal.IsReached())
                {
                    staticVars.increaseExperience(staticVars.quest.experienceReward);
                    staticVars.increaseCurrency(staticVars.quest.currencyReward);
                    staticVars.questCompleteWindow.SetActive(true);
                    staticVars.quest.Complete();
                }
            }
            Destroy(gameObject);
        }
        /*if (wasPickedUp)
        {
            numberHeld++;
            m_MyText.text = "Number of Items Collected: " + numberHeld + " item(s)";
            if(myLight != null)
            {
                myLight.intensity += .05f;
            }
            PlayerManager.instance.player.GetComponent<CharacterStats>().HealDamage(10);
            Destroy(gameObject);
        }*/
    }
}
