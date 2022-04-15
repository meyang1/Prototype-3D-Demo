using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Fade;
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
        Fade.GetComponent<Animator>().SetInteger("AnimState", 1);
        StartCoroutine(WaitSec(sceneIndex)); 


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
    IEnumerator WaitSec( int sceneIndex)
    {
        this.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

}
