using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Instantiate(explosionPrefab,transform.position, Quaternion.identity);
        //Destroy(gameObject);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;
        ObjectPool.Instance.PushObject(gameObject);
        if(other.gameObject.tag == "Hittable")
        {
            Destroy(other.gameObject);
        }
    }
}
