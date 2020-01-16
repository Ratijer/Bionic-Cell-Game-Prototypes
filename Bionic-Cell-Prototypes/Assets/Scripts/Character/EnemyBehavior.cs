using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Stats")]
    public Transform player;
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
    private int element;
    public List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        //For patrol state
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, waypoints.Count);
        //Find closest point so the plane will travel to it
        element = FindNearestPoint();
    }

    // Update is called once per frame
    void Update()
    {
        ServicePatrolState();
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
    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.position;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }

    private void ServicePatrolState()
    {
        //Pick waypoint randomly
        if (randomMovement == true)
        {
            //Enemy will move in the direction of waypoint
            //Move 
            transform.position += transform.up * speed * Time.deltaTime;
            //Point towards point
            PointAtPosition(waypoints[randomSpot].position, rotateSpeed);

            //Prepare to change point
            if (Vector3.Distance(transform.position, waypoints[randomSpot].position) < 25f)
            {
                randomSpot = Random.Range(0, waypoints.Count);
            }
        }
        //Travel waypoints in a specific sequence
        else    //RandomPath == false
        {
            ////Enemy will move in the direction of waypoint
            ////Move 
            //transform.position += transform.up * speed * Time.deltaTime;
            ////Point towards point
            PointAtPosition(waypoints[element].position, rotateSpeed);

            ////Prepare to change point
            //if (Vector3.Distance(transform.position, waypoints[element].position) < 25f)
            //{
            //    //Go to next waypoint
            //    element++;
            //}
            ////Reset sequence
            //if (element >= waypoints.Count)
            //{
            //    element = 0;
            //}
        }
    }
}
