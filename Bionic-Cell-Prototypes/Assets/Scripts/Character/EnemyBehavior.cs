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
    private int current;
    public List<Transform> waypoints;

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
    private void PointAtPosition(Vector2 p, float r)
    {
        Vector2 v = p - (Vector2)transform.position;
        transform.up = Vector2.LerpUnclamped(transform.up, v, r);
    }

    private void ServicePatrolState()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < 1)
        {
            current = Random.Range(0, waypoints.Count);
            if (current >= waypoints.Count)
            {
                current = 0;
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);  //Move without rotation
        transform.position += transform.up * speed * Time.smoothDeltaTime;
        PointAtPosition(waypoints[current].transform.position, rotateSpeed);
    }
}
