using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public bool inScene = false;
    private bool passed = false;
    public string type;
    public Text m_MyText;
    Animator animator;
    public static int numberHeld=0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        inScene = true;
        type = "egg";
        Debug.Log(gameObject.name + " has been created");
        m_MyText.text = "Number of Eggs Collected: " + numberHeld + " egg(s)";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && passed == false){
            passed=true;
            Debug.Log(gameObject.name + " has been picked up"); 
            animator.SetInteger("AnimState", 1);
            numberHeld++;
            m_MyText.text = "Number of Eggs Collected: " + numberHeld + " egg(s)";
            inScene = false;
            StartCoroutine(WaitForSeconds(1f));
        }
    } 

    IEnumerator WaitForSeconds(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log(numberHeld + " egg(s) have been picked up");
        Destroy(gameObject);
    }
}
