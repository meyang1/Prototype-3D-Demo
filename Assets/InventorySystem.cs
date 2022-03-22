using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public static GameObject[] Inventory;
    public int position = 0;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = new GameObject[20];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addObject(GameObject item)
    {
        Inventory[position] = item;
    }
}
