using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsControl : MonoBehaviour
{
    public float moveSpeed;
    public float startTime;
    public float waitTime;

    public Transform leftPos;
    public Transform rightPos;
    public Transform movePos;
    // Start is called before the first frame update
    void Start()
    {
        //base.Start();
        waitTime = startTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();
        transform.position = Vector2.MoveTowards
                                     (transform.position, movePos.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos.position) < 0.05f)
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
    }
    Vector2 GetRandomPos()
    {
        Vector2 randomPosition = new Vector2(Random.Range(leftPos.position.x, rightPos.position.x),
            Random.Range(leftPos.position.y, rightPos.position.y));
        return randomPosition;
    }
}
