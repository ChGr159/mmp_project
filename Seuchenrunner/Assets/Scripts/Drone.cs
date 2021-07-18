using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//drone horizontal movement and functions
public class Drone : MonoBehaviour
{


    //variables for positions
    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 tempPos;

    //variables speed, patrolrange
    public float speed;
    public float patrolrange;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

        //initialize at start position
        startPos = transform.position;

        tempPos = startPos;

        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Drone patrolling horizontally
        newPos = startPos;
        newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, patrolrange);
        transform.position = newPos;

        //flip Drone to face moving direction
        //movement right
        if(newPos.x > tempPos.x)
        {
            sr.flipX = true;
        }
        //movement left
        else
        {
            sr.flipX = false;
        }

        tempPos = newPos;
    }

}
