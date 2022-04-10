using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    public Item item;
    public GameObject gameObjectItem;
    public Light myLight;
    public Text m_MyText;
    public static int numberHeld = 0;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    { 
        Debug.Log("Picking up " + item.name);

        //add to inventory //Inventory.instance.Add(item); 
        var picked = gameObject.GetComponent<ItemContainer>();

        bool wasPickedUp = Inventory.instance.Add(gameObject.GetComponent<ItemContainer>().Data);

        if (wasPickedUp)
        {
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
