using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    public float flySpeed = 5.0f;
    public float circleRadius;
    private Rigidbody2D rb;

    public GameObject topCheck, wallCheck, rootCheck;
    public LayerMask whatIsGround;

    public bool facingRight = true, isToucingWall, isToucingTop, isTouchingRoot;

    public float dirX = 1.0f, dirY = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        CheckSurrounding();
        HitLogic();
        ApplyMovement();
    }

    private void CheckSurrounding()
    {
        isToucingWall = Physics2D.OverlapCircle(wallCheck.transform.position, circleRadius, whatIsGround);
        isTouchingRoot = Physics2D.OverlapCircle(rootCheck.transform.position, circleRadius, whatIsGround);
        isToucingTop = Physics2D.OverlapCircle(topCheck.transform.position, circleRadius, whatIsGround);

    }

    private void HitLogic()
    {
        if (isToucingWall && facingRight)
        {
            Flip();
        }
        else if (isToucingWall && !facingRight)
        {
            Flip();
        }
        if (isTouchingRoot)
        {
            dirY = 0.25f;
        }
        else if (isToucingTop)
        {
            dirY = -0.25f;
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(dirX, dirY) * flySpeed;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        dirX = -dirX;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(wallCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(topCheck.transform.position, circleRadius);
        Gizmos.DrawWireSphere(rootCheck.transform.position, circleRadius);
    }
}
