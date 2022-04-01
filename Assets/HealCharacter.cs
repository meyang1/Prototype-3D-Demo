using UnityEngine;
using UnityEngine.UI;

public class HealCharacter : Interactable
{ 
    public override void Interact()
    {
        base.Interact();
        Heal();
    }

    void Heal()
    {

        PlayerManager.instance.player.GetComponent<CharacterStats>().HealDamage(30);
    }
}
