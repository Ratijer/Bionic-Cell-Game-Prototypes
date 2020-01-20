using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    [Header("Stats")]
    public Transform target;    //Target to follow or point towards. Target is not a waypoint
    public float speed;
    public float health;
    public float damage;
    public float rotateSpeed;

    ////For testing only
    //public bool rotateTowardsPoint;     //Rotates towards waypoint
    //public bool rotateTowardsPlayer;     //Cannot have this and rotateTowardsPoint be true at the same time

    [Header ("Patrol")]
    public bool randomMovement;
    protected int randomSpot;
    protected int current;    //Represents current waypoint the enemy is moving towards
    public List<Transform> waypoints;

    public bool useWP;

    // Start is called before the first frame update
    void Start()
    {
        //For patrol state
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

    protected int FindNearestPoint()
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
    protected void PointAtPosition(Vector2 p, float r)
    {
        Vector2 v = p - (Vector2)transform.position;
        transform.up = Vector2.LerpUnclamped(transform.up, v, r);
    }

    protected void ServicePatrolState()
    {
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
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed); 
        PointAtPosition(waypoints[current].transform.position, rotateSpeed);    //Point towards waypoint
    }

    protected void ServiceFollowState()
    {
        if (Vector3.Distance(target.position, transform.position) < 1.5f)
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

    public void TakeDamage(float damage)
    {
        Debug.Log("NPC/Enemy was hit!");
        health -= damage;
        Debug.Log("NPC Health: " + health);
        if (health <= 0)
        {
            Debug.Log("NPC/Enemy has died");
        }
    }

    public virtual void ApplyEffect()
    {

    }
}
