using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    StaticVariablesCharacter staticVars;
    public event System.Action<int, int> OnHealthChanged;
    // Start is called before the first frame update
    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        currentHealth = staticVars.currentHealth;
        maxHealth = staticVars.maxHealth;
        currentHealth = staticVars.currentHealth;
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged; 
    }

    void Awake()
    {
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }
    public override void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // set limits to the damage variable;

        currentHealth -= damage;
        staticVars.currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            Debug.Log("Player health " + currentHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = staticVars.maxHealth;
            staticVars.currentHealth = staticVars.maxHealth;
            Die(); //for players, gameover/respawn; for enemies, drop loot and disappear
        }

    }
    public virtual void HealDamage(int heal)
    { 
        heal += staticVars.currentHealth;
        heal = Mathf.Clamp(heal, 0, staticVars.maxHealth);
        currentHealth = heal;
        staticVars.currentHealth = heal;

        //OnHealthChanged(maxHealth, currentHealth);
    }
    public override void Die()
    {
        base.Die();
        // Kill the player --> death animation, game over screen, respawn prompt, etc...
        PlayerManager.instance.KillPlayer();
    }
}
