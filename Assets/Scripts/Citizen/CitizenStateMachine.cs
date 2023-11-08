using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenStateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState;
    public ArrestingState arrestingState;

    public void Initialise()
    {
        patrolState = new PatrolState();
        arrestingState = new ArrestingState();
        // ChangeState(patrolState);
    }

    void Update()
    {
        if (activeState != null) {
            activeState.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null) {
            activeState.Exit();
        }

        activeState = newState;

        if (activeState != null) {
            activeState.stateMachine = this;
            activeState.citizen = GetComponent<Citizen>();
            activeState.Enter();
        }
    }
}
