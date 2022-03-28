using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //Singleton Pattern - Basic - Important for game managers
    #region Singleton
    public static Inventory instance; //static var with same type as class

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of Inventory found....");
            return;
        }
        instance = this; // when start, setting equal to this particular component (can access by Inventory.instance)
    }

    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback; //different methods subscribed to this event

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null) 
                onItemChangedCallback.Invoke(); //trigger the event to update Inventory UI

        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); //trigger the event to update Inventory UI
    }
}
