using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float interval;
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    private Transform muzzlePos;
    private Transform shellPos;
    private Vector2 mousePos;
    private Vector2 direction;
    private float timer;
    private float filpy;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        muzzlePos = transform.Find("Muzzle");
        shellPos = transform.Find("BulletShell");
        filpy = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(filpy, -filpy, 1);
        }
        else
        {
            transform.localScale = new Vector3(filpy, filpy, 1);
        }
        Shoot();
    }
    void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.right = direction;
        if(timer != 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
                timer = 0;
        }
        if (Input.GetButton("Fire1"))
        {
            if(timer == 0)
            {
                Fire();
                timer = interval;
            }
        }

    }
    void Fire()
    {
        animator.SetTrigger("Shoot");
        GameObject bullet = Instantiate(bulletPrefab,muzzlePos.position,Quaternion.identity);
        bullet.GetComponent<Bullet>().SetSpeed(direction);
        Instantiate(shellPrefab,shellPos.position,shellPos.rotation);
    }
}
