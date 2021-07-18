using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls movement of camera
public class Camera2DFollow : MonoBehaviour
{
    //variables
    public Transform target;
    public float damping = 1;                       //damping how fast camera follows the object
    public float lookAheadFactor = 3;               //look ahead of the object
    public float lookAheadReturnSpeed = 0.5f;       //focus back to object after stopping
    public float lookAheadMoveThreshold = 0.1f;     //threshold for look ahead while moving
    public float yPosRestriction;
    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;
    float nextTimeToSearch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //initialize with target position
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if target lost => FindPlayer method called
        if (target == null)
        {
            FindPlayer();                   
            return;
        }

        //variables to determine position
        float xMoveDelta = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        //update to adjust look ahead of camera
        if(updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        newPos = new Vector3(newPos.x, Mathf.Clamp (newPos.y, yPosRestriction, Mathf.Infinity), newPos.z);

        transform.position = newPos;
        lastTargetPosition = target.position;
    }

    //FindPlayer method to refocus on Player
    void FindPlayer()
    {
        if (nextTimeToSearch <= Time.time)
        {
            GameObject searchresult = GameObject.FindGameObjectWithTag("Player");
            if (searchresult != null)                             //if gameObject found => new target 
            {
                target = searchresult.transform;                    
            }
            nextTimeToSearch = Time.time + 0.5f;                  //search time adjusted if necessary
        }
    }
}
