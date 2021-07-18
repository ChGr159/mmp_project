using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls behaviour of bullet at impact
public class BulletBehavior : MonoBehaviour
{
    public GameObject impactEffect;

    // Start is called before the first frame update
    //impact effect called at bullet collision with other game object
    void OnCollisionEnter2d(Collision2D other)
    {
        GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation)as GameObject;

        Destroy(gameObject);
    }
}
