using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineTransition : MonoBehaviour
{
    public LevelManager lvlManager;
    // Start is called before the first frame update 
    void Awake()
    {
        lvlManager.GetComponent<AudioSource>().Pause();
        lvlManager.LoadNextScene(4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
