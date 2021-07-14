using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletLifetime = 3;
    public Transform enemy;
    public Transform target;
    float nextTimeToSearch = 0f;
    public Transform firePoint;
    public float fireRate;
    private float nextShot = 0f;
    private bool m_FacingRight = true;  // For determining which way the go is currently facing.

    void Update()
    {
        if (target == null)
        {
            FindPlayer();                   //falls das target verloren gegangen sein sollte wird die Funktion FindPlayer() aufgerufen
            return;
        }
    }    
    void FixedUpdate()
    {
        
        if (target.position.x < enemy.position.x && m_FacingRight == true)
        {
            Flip();
            m_FacingRight = false;
        }
        else if (target.position.x > enemy.position.x && m_FacingRight == false)
        {
            Flip();
            m_FacingRight = true;
        }
        else
        {
            return;
        }
    }
    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        //Vector3 theScale = enemy.transform.localScale;
        //theScale.x *= -1;
        //enemy.transform.localScale = theScale;
        enemy.transform.Rotate(0, -180, 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (nextShot < Time.time)
            {
                Shoot();
                nextShot = Time.time + fireRate;
            }
        }

    }

    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, firePoint.position, firePoint.rotation)as GameObject;
        Rigidbody2D instBulletrb = instBullet.GetComponent<Rigidbody2D>();
        if (m_FacingRight == true)
        {
            instBulletrb.AddForce(Vector2.right * bulletSpeed);
        }
        else
        {
            instBulletrb.AddForce(Vector2.left* bulletSpeed);
        }
        
        Destroy(instBullet, bulletLifetime);


    }
    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchresult = GameObject.FindGameObjectWithTag("Player");
            if (searchresult != null)                             //Falls ein GameObject gefunden wird, wird ein neues Ziel für die Kamera gesetzt
            {
                target = searchresult.transform;
            }
            nextTimeToSearch = Time.time + 0.5f;                  //Die Zeit zum Suchen wird erhöht, falls eine erneute Suche notwendig ist
        }
    }
}