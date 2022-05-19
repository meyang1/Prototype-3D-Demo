using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    StaticVariablesCharacter staticVars;
    public Image healthSlider;
    public Transform ui;
    public float healthPercent;
    float visibleTime = 3;

    float lastMadeVisibleTime;
    // Start is called before the first frame update
    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;

        Image healthSlider;
        healthSlider =  GetComponent<Image>(); 
    }

    // Update is called once per frame
    void Update()
    {
        healthPercent = (float)staticVars.currentHealth / staticVars.maxHealth;
        healthSlider.fillAmount = healthPercent; 

    }

     
}
