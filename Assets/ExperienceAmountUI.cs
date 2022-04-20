using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceAmountUI : MonoBehaviour
{
    StaticVariablesCharacter staticVars;
    public Image expSlider;
    public Transform ui;
    public float expPercent;
    float visibleTime = 3;

    float lastMadeVisibleTime;
    // Start is called before the first frame update
    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;

        Image expSlider;
        expSlider = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        expPercent = (float)staticVars.experienceAmount / 100;
        expSlider.fillAmount = expPercent;

    }

}
