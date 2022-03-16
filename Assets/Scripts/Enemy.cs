using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject hit;
    [SerializeField] private Transform parent;
    [SerializeField] private int pointValue = 1;
    [SerializeField] private int hitPoints = 2;

    private Scoreboard scoreboard;

    private void Start() {
        scoreboard = FindObjectOfType<Scoreboard>();
        //makes sure all enemies have rigidbodies in order to get collision within child objects
        Rigidbody rb  = this.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(explosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hit, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;

        hitPoints--;
        scoreboard.IncreaseScore(pointValue);
    }
}
