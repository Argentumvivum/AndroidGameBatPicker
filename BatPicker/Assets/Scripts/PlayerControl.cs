using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D rB;
    public float speed;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundRadius;

    private void Awake()
    {
        rB = transform.GetComponent<Rigidbody2D>();
    }

    public void GoRight()
    {
        if (speed < 0)
            speed *= -1;
        else
            speed *= 1;

        rB.velocity = new Vector2(speed, 0);
    }

    public void GoLeft()
    {
        if (speed > 0)
            speed *= -1;
        else
            speed *= 1;

        rB.velocity = new Vector2(speed, 0);
    }

    public void Jump()
    {
        if(isGrounded)
            rB.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }
}
