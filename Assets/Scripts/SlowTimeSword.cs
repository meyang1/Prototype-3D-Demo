using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeSword : MonoBehaviour
{
    public bool hitSomething = false;
    public AudioClip _sideThrust;
    public AudioClip _doubleThrust;
    public AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Primary" || collision.gameObject.tag == "Item")
        {
            hitSomething = true;
            _audioSource.PlayOneShot(_sideThrust, 0.7F);
            StartCoroutine(SwordSlow(1f));
        } 
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Primary" || collision.gameObject.tag == "Item")
        { 
            Time.timeScale = 1f;
        }
    }
    IEnumerator SwordSlow(float timeDelay)
    {
        Time.timeScale = .5f;
        yield return new WaitForSeconds(.2f);

        Time.timeScale = 1f;
    }
}
