using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Jedi");
        Speed();
    }
    public void Speed()
    {
        rigidbody.velocity =  (new Vector2(player.transform.position.x,player.transform.position.y) - rigidbody.position).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Instantiate(explosionPrefab,transform.position, Quaternion.identity);
        //Destroy(gameObject);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;
        ObjectPool.Instance.PushObject(gameObject);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You Loss");
        }
    }
}
