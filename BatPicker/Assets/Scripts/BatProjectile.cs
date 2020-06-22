using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatProjectile : MonoBehaviour {

    public LayerMask playerMask;
    public LayerMask borderMask;
    public LayerMask projectileMask;
    public bool hitPlayer;
    public bool hitBorder;
    public bool isProjectileHit;
    public Collider2D hitPlayerProjectile;

    public Manager manager;

    private void FixedUpdate()
    {
        hitPlayer = Physics2D.OverlapCircle(transform.position, 0.1f, playerMask);
        hitBorder = Physics2D.OverlapCircle(transform.position, 0.1f, borderMask);
        isProjectileHit = Physics2D.OverlapCircle(transform.position, 0.1f, projectileMask);

        if (hitPlayer && manager.canBeDamaged)
        {
            manager.playerHealth -= 1;
            manager.canBeDamaged = false;
            Destroy(gameObject);
        }
            
        if (hitBorder)
            Destroy(gameObject);

        if (isProjectileHit)
        {
            hitPlayerProjectile = Physics2D.OverlapCircle(transform.position, 0.1f, projectileMask);
            Destroy(hitPlayerProjectile.gameObject);
            Destroy(gameObject);
        }
    }
}
