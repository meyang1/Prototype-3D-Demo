using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _fastSword;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();   
        if(_audioSource == null)
        {
            Debug.Log("No audiosource player");
        }
        else
        {
            _audioSource.clip = _fastSword;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _audioSource.Play();
        }
        
    }
}
