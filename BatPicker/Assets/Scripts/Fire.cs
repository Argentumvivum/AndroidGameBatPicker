using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject pickSpawner;
    public PlayerControl pC;
    private ThrowControl throwControl;
    private SpriteRenderer renderer;
    public AudioSource audioSource;
    public AudioClip[] clips;

    private void Start()
    {
        throwControl = pickSpawner.GetComponent<ThrowControl>();
        renderer = transform.GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (pC.speed > 0)
            renderer.flipX = true;
        else
            renderer.flipX = false;
    }

    public void FireProjectile()
    {
        throwControl.SpawnProjectile();
        audioSource.PlayOneShot(clips[0]);
    }
}
