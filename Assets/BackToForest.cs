using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToForest : MonoBehaviour
{
    public LevelManager lvlManager;
    // Start is called before the first frame update 
    void Awake()
    {
        lvlManager.GetComponent<AudioSource>().Pause();
        lvlManager.LoadNextScene(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
