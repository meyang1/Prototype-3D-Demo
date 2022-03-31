using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class losescript : MonoBehaviour
{
    public LevelManager lvlmanager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up") || Input.GetKey("right")){
            lvlmanager.LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
        }
        if(Input.GetKey("down")|| Input.GetKey("left")){
            lvlmanager.LoadLevel(SceneManager.GetActiveScene().buildIndex-1);
        }
    } 
    public void NextScene()
    {
        lvlmanager.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
