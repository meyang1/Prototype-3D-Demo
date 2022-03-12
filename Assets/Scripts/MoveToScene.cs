using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToScene : MonoBehaviour
{
    public LevelManager lvlmanager;
    public string str = "Game";
    bool check = false;
    bool m_SceneLoaded;
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
        // LoadSceneButton();
        lvlmanager.LoadLevel(str);
    }
    IEnumerator LoadInScene()
    {
        SceneManager.LoadScene(str, LoadSceneMode.Additive);
        yield return new WaitForSeconds(3);
        //yield return 0; // wait a frame, so it can finish loading
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(str));
        lvlmanager.LoadLevel(str);
        check = false;
    }
    void LoadSceneButton()
    {
        // Check that the second Scene hasn't been added yet
        if (m_SceneLoaded == false)
        {
            // Loads the second Scene
            SceneManager.LoadScene(str, LoadSceneMode.Additive);

            // Outputs the name of the current active Scene.
            // Notice it still outputs the name of the first Scene
            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);

            // The Scene has been loaded, exit this method
            m_SceneLoaded = true;
        }
    }

    // Change the newly loaded Scene to be the active Scene if it is loaded
    void SetActiveSceneButton()
    {
        // Allow this other Button to be pressed when the other Button has been pressed (Scene 2 is loaded)
        if (m_SceneLoaded == true)
        {
            // Set Scene2 as the active Scene
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(str));

            // Ouput the name of the active Scene
            // See now that the name is updated
            Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        }
    }
}
