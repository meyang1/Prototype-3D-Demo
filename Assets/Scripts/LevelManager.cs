    using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject Fade;
    StaticVariablesCharacter staticVars; 
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(WaitSec(sceneIndex));
    }
    void Start()
    {
        staticVars = StaticVariablesCharacter.Eyevon;
        staticVars.fadeToBlack.SetActive(false);
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
    public void LoadNextScene()
    {
        StartCoroutine(NextScene(SceneManager.GetActiveScene().buildIndex+1));
        
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
        staticVars.fadeToBlack.SetActive(true);

        this.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(.75f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    IEnumerator NextScene(int sceneIndex)
    {
        Fade.SetActive(true);

        this.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }

}
