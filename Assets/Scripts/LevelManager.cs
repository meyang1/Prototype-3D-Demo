using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex){

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone){
            Debug.Log(operation.progress);

            yield return null; //wait until the next frame 
        }
    }
    
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);


    }
    public void LoadNextScene(){
        
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        
    }
    public void LoadLastScene(){
        
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex-1);
        
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
    
}
