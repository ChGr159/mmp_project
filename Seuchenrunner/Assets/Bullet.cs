using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    private Rigidbody2D rb;
    public float bulletLifetime =3;


    // Start is called before the first frame update
    
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        Vector3 move = new Vector3(1, 0, 0);
        move = move.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + move);
    }

    
}
