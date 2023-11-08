using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public float waitTimer = 0f;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
    }

    public void PatrolCycle()
    {
        if (citizen.Agent.remainingDistance < 0.2f) {
            waitTimer += Time.deltaTime;

            if (waitTimer > 3) {
                if (waypointIndex < citizen.Path.Waypoints.Count - 1) {
                    waypointIndex++;
                } else {
                    waypointIndex = 0;
                }

                citizen.Agent.SetDestination(citizen.Path.Waypoints[waypointIndex].position);
                waitTimer = 0f;
            }
        }
    }
}
