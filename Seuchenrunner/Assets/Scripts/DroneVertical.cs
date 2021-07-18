using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//drone vertical movement and functions
public class DroneVertical: MonoBehaviour
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

        //random speed
        speed = Random.Range(5f, 10f);

        tempPos = startPos;

        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Drone patrolling vertically
        newPos = startPos;
        newPos.y = newPos.y + Mathf.PingPong(Time.time * speed, patrolrange);
        transform.position = newPos;

        tempPos = newPos;
    }

}
