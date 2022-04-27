using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    StaticVariablesCharacter staticVars;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = staticVars.currentHealth + "/" + staticVars.maxHealth;
    }
}
