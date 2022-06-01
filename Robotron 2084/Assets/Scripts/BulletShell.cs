using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    public float speed;
    public float stopTime = .5f;
    public float fadeSpeed = .01f;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        rigidbody.velocity = Vector3.up * speed;
        StartCoroutine(Stop());
    }

    // Update is called once per frame
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        while(sprite.color.a > 0)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g,sprite.color.a - fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        Destroy(gameObject);
    }
}
