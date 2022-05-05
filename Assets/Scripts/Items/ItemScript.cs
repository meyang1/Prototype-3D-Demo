using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private bool passed = false;
    public Item item; 

    public Text m_MyText;
    //public static int numberHeld;
    Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(gameObject.name + " has been created");
        m_MyText.text = "Number of Eggs Collected: " + ItemPickup.numberHeld + " egg(s)";
    }

     
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && passed == false){
            passed=true;
            animator.SetInteger("AnimState", 1);

            ItemPickup.numberHeld++;
            m_MyText.text = "Number of Eggs Collected: " + ItemPickup.numberHeld + " egg(s)";

            //Inventory.instance.Add(item);

            StartCoroutine(WaitForSeconds(1f));
        }
    } 

    IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
