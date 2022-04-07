using UnityEngine;
using UnityEngine.UI;

public class HealCharacter : Interactable
{ 
    public override void Interact()
    {
        base.Interact();
        //if(PlayerManager.instance.player2.transform.GetComponent<SecondaryPlayerController>().focus != PlayerManager.instance.player2.transform.GetComponent<SecondaryPlayerController>().defaultFocus)
        //{
         //   Heal(10);
        //}
        //else
        //{
            Heal(30);

       // }
    }

    void Heal(int healthAmount)
    {

        PlayerManager.instance.player.GetComponent<CharacterStats>().HealDamage(healthAmount);
    }
}
