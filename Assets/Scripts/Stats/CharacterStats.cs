 
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged; //max health and current health

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // set limits to the damage variable;

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
            Debug.Log("Current health " + currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die(); //for players, gameover/respawn; for enemies, drop loot and disappear
        }
    }

    public void HealDamage(int heal)
    {
        heal += currentHealth;
        heal = Mathf.Clamp(heal, 0, maxHealth);
        currentHealth = heal;
    }

    public virtual void Die()
    {
        //Die in some way 
        //method meant to be overwritten
        Debug.Log(transform.name + " died.");
    }


}
