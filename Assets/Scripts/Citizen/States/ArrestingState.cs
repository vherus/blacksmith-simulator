using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestingState : BaseState
{
    private const string ARRESTING = "Arresting";

    private bool isBeingArrested = false;
    private Transform playerTransform;
    private Transform citizenTransform;

    public override void Enter()
    {
        isBeingArrested = true;
        citizenTransform = citizen.gameObject.GetComponent<Transform>();
        playerTransform = citizen.PlayerAnimator.gameObject.GetComponent<Transform>();

        float distanceFromPlayer = 0.75f;
        Vector3 frontOfPlayer = playerTransform.position + (playerTransform.forward * distanceFromPlayer);
        citizen.Agent.SetDestination(frontOfPlayer);

        citizen.PlayerAnimator.SetTrigger("Arrest");
        citizen.Animator.SetBool(ARRESTING, true);
    }

    public override void Exit()
    {
        citizen.PlayerAnimator.SetTrigger("Dearrest");
        citizen.Animator.SetBool(ARRESTING, false);
    }

    public override void Perform()
    {
        FaceAwayFromPlayer();
    }

    private void FaceAwayFromPlayer()
    {
        if (isBeingArrested && citizen.Agent.remainingDistance <= 0) {
            Quaternion lookRotation = playerTransform.rotation;
            citizenTransform.rotation = Quaternion.Slerp(citizenTransform.rotation, lookRotation, Time.deltaTime * 5);
            
            if (playerTransform.rotation.y.ToString("N3") == (citizenTransform.rotation.y * -1).ToString("N3")) {
                isBeingArrested = false;
            }
        }
    }
}
