using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//set new spawnpoint when checkpoint is passed
public class Spawnpoint : MonoBehaviour
{
    
    //variable spawn position
    private Transform spawnposition;

    private void Awake()
    {
        spawnposition = GetComponent<Transform>();
    }

    //if checkpoint is passed by player => next respawn at checkpoint position instead of start position
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Checkpoint erreicht");
            GameMaster.CheckPoint(spawnposition);

        }
    }
}
