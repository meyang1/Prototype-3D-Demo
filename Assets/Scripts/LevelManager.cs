using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitGame()
    {

        this.GetComponent<AudioSource>().Play();
        StartCoroutine(ExecuteAfterTime(2));
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Application.Quit();
    }
    void Awake () {
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 15;
 }
}
