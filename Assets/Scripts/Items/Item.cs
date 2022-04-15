using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{
    //basic properties for all items
    new public string name = "New Item"; //overwrite default property of name
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool healItem = false;

    public virtual void Use() //not implementing functionality b/c different uses for different items; allows you to derive for each one
    {
        //Use the item

        //GetComponent<CharacterStats>().HealDamage(2);
        //Something might happen

        Debug.Log("Using " + name);
        if (healItem)
        {
            RemoveFromInventory();
        }
    }

    public void RemoveFromInventory()
    {
        PlayerManager.instance.player.GetComponent<PlayerStats>().HealDamage(10);
        Inventory.instance.Remove(this);
    }
}
