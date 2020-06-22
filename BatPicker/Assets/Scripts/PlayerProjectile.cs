using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    private void Awake()
    {
        Invoke("RemovePick", 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    void RemovePick()
    {
        Destroy(gameObject);
    }
}
