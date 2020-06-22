using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack : MonoBehaviour {

    public GameObject projectilePrefab;
    public GameObject projectileSpawnPoint;
    public GameObject batPrefab;
    private GameObject player;
    private Manager manager;
    public float projectileSpeed;
    private GameObject projectileClone;
    public float timeAfterSpawn;
    public float attackRepeatTime;
    public Bat bat;
    public AudioSource audio;

    public void StartAttacking()
    {
        SetAudio();
        attackRepeatTime = Random.Range(1, attackRepeatTime);
        player = FindObjectOfType<Manager>().player;
        manager = FindObjectOfType<Manager>();
        batPrefab.GetComponent<BoxCollider2D>().enabled = true;
        InvokeRepeating("Attack", timeAfterSpawn, attackRepeatTime);
    }

    void Attack()
    {
        Vector2 pos = projectileSpawnPoint.transform.position;
        Vector2 dir = (new Vector2(player.transform.position.x, player.transform.position.y)) - pos;
        dir.Normalize();

        projectileClone = Instantiate(projectilePrefab) as GameObject;
        projectileClone.transform.position = pos;
        Rigidbody2D rb = projectileClone.GetComponent<Rigidbody2D>();
        rb.velocity = dir * projectileSpeed;

        Vector2 moveDir = rb.velocity;
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        projectileClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        projectileClone.GetComponent<BatProjectile>().manager = manager;
        audio.PlayOneShot(bat.clips[0], 0.5f);
    }

    public void StopAttack()
    {
        CancelInvoke();
    }

    void SetAudio()
    {
        audio.mute = FindObjectOfType<GameManager>().options.sfx;
    }
}
