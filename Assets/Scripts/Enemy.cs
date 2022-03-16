using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private Transform parent;
    private void OnParticleCollision(GameObject other) {
        GameObject vfx = Instantiate(explosion, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(this.gameObject);
    }
}
