using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//controls Enemy2 (turret) explosion
public class Enemy2 : MonoBehaviour
{
    public GameObject Explosion;

    //if player jumps on Enemy2 => Enemy2 explodes, destroyed
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            SoundManager.PlaySound("explosion");
            Debug.Log("Gegner ist getötet");
        }
    }










}