using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls player behaviour using ladders
public class LadderBehaviour : MonoBehaviour

{
    //variables
    public float ClimbingSpeed;
    public float playergrav;
    private GameObject Player;

    //find player and set gravity
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playergrav = Player.GetComponent<Rigidbody2D>().gravityScale;
    }

    //moving up and down using ladders
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;

            if (Input.GetKey(KeyCode.W))                        //moving up with key "W"
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ClimbingSpeed);
            }
            else if (Input.GetKey(KeyCode.S))                   //moving down with key "S"
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ClimbingSpeed);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);     //else no movement
            }

        }
    }

    //dismount ladder
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = playergrav;
        }
    }
}
