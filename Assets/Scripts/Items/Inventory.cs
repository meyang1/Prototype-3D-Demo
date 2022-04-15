using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Singleton Pattern - Basic - Important for game managers
    #region Singleton
    public static Inventory instance; //static var with same type as class
    public Text notificationText;
    public GameObject notification;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
             Destroy(this.gameObject);
        } // when start, setting equal to this particular component (can access by Inventory.instance)
        DontDestroyOnLoad(this.gameObject);
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
                notificationText.text = "Bag is full!"; 
                StartCoroutine(NotificationDelay(.2f));
                return false;
            }
            items.Add(item);
            notificationText.text = item.name + "+1";
            StartCoroutine(NotificationDelay(.1f));

            if (onItemChangedCallback != null) 
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

    IEnumerator NotificationDelay(float timeDelay)
    {
        yield return new WaitForSeconds(.5f);
        notification.GetComponent<Animator>().SetInteger("AnimState", 1);
        yield return new WaitForSeconds(timeDelay);
        notification.GetComponent<Animator>().SetInteger("AnimState", 0);
    }
}
