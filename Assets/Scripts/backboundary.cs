using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine; 

public class backboundary : MonoBehaviour
{
    public LevelManager lvlmanager;
    public int sceneIndexBoundary;
    public bool checkDone;
    // Start is called before the first frame update
    void Start()
    {
        checkDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerCharacter" && checkDone == false) { 
    
            lvlmanager.LoadScene(sceneIndexBoundary);
            checkDone = true;
        }
    }
}
