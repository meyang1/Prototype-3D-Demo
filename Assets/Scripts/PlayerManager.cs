using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    public GameObject player2;


    public void KillPlayer()
    {
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}