using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup canvasGroup;
    void Start()
    {
        //StartCoroutine(FadeLoadingScreen(2f));
        
    }
    //IEnumerator FadeLoadingScreen(float duration)
    //{
       /* float startValue = canvasGroup.Alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.getAlpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.Alpha = 1;*/
   // }
   // }
}
