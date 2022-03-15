using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string sceneToLoad;
    
    Slider progressBar;
    public Text percentLoaded;
    AsyncOperation loadingOperation;
    
    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
    }
    void Update()
    {
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        percentLoaded.text = Mathf.Round(progressValue * 100) + "%";
    }
    
}
