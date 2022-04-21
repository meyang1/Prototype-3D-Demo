using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShootBall(10f));
        
    }

    IEnumerator ShootBall(float timeDelay)
    { 
        yield return new WaitForSeconds(timeDelay);

        GameObject ball = Instantiate(projectile, transform.position,
                                             transform.rotation);

        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                         (0, launchVelocity, 0));
    }
}
