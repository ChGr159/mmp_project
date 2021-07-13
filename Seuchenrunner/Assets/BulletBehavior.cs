using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject impactEffect;
    // Start is called before the first frame update
    void OnCollisionEnter2d(Collision2D other)
    {
        GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation)as GameObject;

        Destroy(gameObject);
    }
}
