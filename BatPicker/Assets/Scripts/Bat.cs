using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    private GameObject player;
    public BatAttack attack;
    private SpriteRenderer renderer;
    private Animator anim;
    private Rigidbody2D rb;
    private AudioSource audio;
    public AudioClip[] clips;

    private void Awake()
    {
        renderer = transform.GetComponent<SpriteRenderer>();
        anim = transform.GetComponent<Animator>();
        player = FindObjectOfType<Manager>().player;
        rb = gameObject.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (player.transform.position.x > transform.position.x)
            renderer.flipX = true;
        else
            renderer.flipX = false;
    }

    public void StartAttack()
    {
        attack.StartAttacking();
    }

    public void StopAttack()
    {
        attack.StopAttack();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "PlayerProjectile")
        {
            audio.PlayOneShot(clips[1]);
            anim.SetInteger("deathNumber", Random.Range(1, 3));
            rb.constraints = RigidbodyConstraints2D.None;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.gameObject);
            Invoke("RemoveBat", 10);
        }
    }

    void RemoveBat()
    {
        Destroy(gameObject);
    }
}
