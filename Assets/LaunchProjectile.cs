using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;  
    private float canShoot = 0f;
    public float timeTillShoot;
    // Start is called before the first frame update
    void Start()
    {
        //this.fixedDeltaTime = Time.fixedDeltaTime;
        //timeTillShoot = Random.Range(.5f, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > canShoot)
        {
            StartCoroutine(ShootBall());
            canShoot = Time.time + timeTillShoot;

        }
        
    }

    IEnumerator ShootBall()
    {
        yield return null;//new WaitForSeconds(timeDelay);

        GameObject ball = Instantiate(projectile, transform.position,
                                             transform.rotation);

        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                         (0, launchVelocity, 0));

        Destroy(ball, .4f);
    }
}
