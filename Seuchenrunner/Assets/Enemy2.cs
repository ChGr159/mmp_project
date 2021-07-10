using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;

    private int currentPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameMaster.KillPlayer(collision.gameObject);     //Leben abziehn
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Gegner ist getötet");      //Bekommt Punkte???
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentPos], speed);
        if (transform.position == positions[currentPos])
        {
            if (currentPos < positions.Length - 1)
            {
                currentPos++;
            }
            else
            {
                currentPos = 0;
            }
        }
    }
}
