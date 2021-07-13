using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    //public Vector3[] positions;
    public GameObject enemyExplosion;
    


    

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instantiate(enemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Gegner ist getötet");      //Bekommt Punkte???
        }
    }

    
    
    
    
    

    


}