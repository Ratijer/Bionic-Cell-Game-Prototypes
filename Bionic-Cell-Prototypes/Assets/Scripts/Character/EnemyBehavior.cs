using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Stats")]
    public Transform target;    //Target to follow. Target is not a waypoint
    public float speed;
    public float health;
    public float rotateSpeed;
    public bool rotateTowardsPoint;     //Usually rotates towards waypoint
    public bool rotateTowardsPlayer;     //Cannot have this and rotateTowardsPoint be true at the same time

    [Header ("Patrol")]
    public bool randomMovement;
    private float waitTime;
    public float startWaitTime = 1;
    private int randomSpot;
    private int current;    //Represents current waypoint the enemy is moving towards
    public List<Transform> waypoints;

    //For testing only
    public bool useWP;

    // Start is called before the first frame update
    void Start()
    {
        //For patrol state
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, waypoints.Count);
        //Find closest point so the plane will travel to it
        current = FindNearestPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //For testing only
        if (useWP)
            ServicePatrolState();
        else
            ServiceFollowState();
    }

    private int FindNearestPoint()
    {
        float[] distances = new float[waypoints.Count];
        int index = 0;
        foreach (Transform waypoint in waypoints)
        {
            distances[index] = Vector3.Distance(transform.position, waypoint.position);
            index++;
        }

        //Nearest point distance and waypoint index
        float minValue = distances.Min();
        int minIndex = distances.ToList().IndexOf(minValue);

        return minIndex;
    }

    //point towards waypoint 
    private void PointAtPosition(Vector2 p, float r)
    {
        Vector2 v = p - (Vector2)transform.position;
        transform.up = Vector2.LerpUnclamped(transform.up, v, r);
    }

    private void ServicePatrolState()
    {
        //if (Vector3.Distance(waypoints[current].transform.position, transform.position) < 1)    //Change waypoint after reaching the current waypoint
        //{
        //    Debug.Log(waypoints[current]);
        //    //current = Random.Range(0, waypoints.Count);
        //    if (current >= waypoints.Count)
        //    {
        //        Debug.Log("Current is above count");
        //        current = 0;
        //    }
        //    else
        //    {
        //        Debug.Log("Current is below count");
        //        current++;
        //    }
        //}


        //Prepare to change point
        if (Vector3.Distance(transform.position, waypoints[current].position) < 1f)
        {
            //Go to next waypoint
            current++;
        }
        //Reset sequence
        if (current >= waypoints.Count)
        {
            current = 0;
        }
        //Move towards point   
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);  //Move without rotation                                                                                                                //Move towards waypoint
        //transform.position += transform.up * speed * Time.smoothDeltaTime;
        PointAtPosition(waypoints[current].transform.position, rotateSpeed);    //Point towards waypoint

    }

    private void ServiceFollowState()
    {
        if (Vector3.Distance(target.position, transform.position) < 2)
        {
            transform.position += transform.up * 0 * Time.smoothDeltaTime;      //Stops moving when it's near the target
        }
        else
        {
            //Move towards target
            transform.position += transform.up * speed * Time.smoothDeltaTime;  
            PointAtPosition(target.position, rotateSpeed);                          
        }
    }
}
