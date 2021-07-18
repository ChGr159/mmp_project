using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls shooting of Enemy2 (turret)
public class Shooting : MonoBehaviour
{
    //variables
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletLifetime = 3;
    public Transform enemy;
    public Transform target;
    float nextTimeToSearch = 0f;
    public Transform firePoint;
    public float fireRate;
    private float nextShot = 0f;
    private bool m_FacingRight = true;  //for determining which way the turret is currently facing

    void Update()
    {
        if (target == null)
        {
            FindPlayer();                   //if target is lost => call FindPlayer method to refocus on player
            return;
        }
    }    

    //flips turret to face direction of player
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
        enemy.transform.Rotate(0, -180, 0);
    }

    //if player nearby => call Shoot method
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

    //shooting using bullet game object
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
        
        Destroy(instBullet, bulletLifetime);        //destroy bullet after bullet lifetime


    }

    //method to refocus on player
    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchresult = GameObject.FindGameObjectWithTag("Player");
            if (searchresult != null)                             //refocus camera on player if found
            {
                target = searchresult.transform;
            }
            nextTimeToSearch = Time.time + 0.5f;                  //adjusts time for search
        }
    }
}