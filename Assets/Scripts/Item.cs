using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName="Inventory/Item")]
public class Item : ScriptableObject
{

    //basic properties for all items
    new public string name = "New Item"; //overwrite default property of name
    public Sprite icon = null;
    public bool isDefaultItem = false;

}
