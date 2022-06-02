using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public GameObject projectile;
    public float nextFire = 2.0f;
    public float currentTime = 1.0f;

    void Update()
    {
        enemyShoot();
    }
    public void enemyShoot()
    {
        currentTime += Time.deltaTime;
        if(currentTime > nextFire)
        {
            nextFire += currentTime;
            Instantiate(projectile,transform.position,projectile.transform.rotation);
            nextFire -= currentTime;
            currentTime = 0.0f;
        }
    }
}
