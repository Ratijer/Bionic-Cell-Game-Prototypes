using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBehavior : NPCBehavior
{
    // Start is called before the first frame update
    void Start()
    {
        //For patrol state
        //randomSpot = Random.Range(0, waypoints.Count);
        //Find closest point so the plane will travel to it
        //current = FindNearestPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //ServicePatrolState();
    }

    public override void ApplyEffect()
    {

    }
}
