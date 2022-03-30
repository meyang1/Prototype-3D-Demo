using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{

    //basic properties for all items
    new public string name = "New Item"; //overwrite default property of name
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use() //not implementing functionality b/c different uses for different items; allows you to derive for each one
    {
        //Use the item
        //Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
