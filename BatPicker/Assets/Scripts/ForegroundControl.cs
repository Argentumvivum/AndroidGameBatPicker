using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundControl : MonoBehaviour {

    public float speed;
    public LayerMask destroyerMask;

    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.5f, destroyerMask))
        {
            Destroy(gameObject);
        }
    }
}
