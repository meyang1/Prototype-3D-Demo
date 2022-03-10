using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToScene : MonoBehaviour
{
    public LevelManager lvlmanager;
    public string str="Game";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision character)
    {
        lvlmanager.LoadLevel(str);
    }

}
