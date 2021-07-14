using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{
    public float ClimbingSpeed;
    public float playergrav;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playergrav = Player.GetComponent<Rigidbody2D>().gravityScale;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ClimbingSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ClimbingSpeed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); 
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = playergrav;
        }
    }
}
