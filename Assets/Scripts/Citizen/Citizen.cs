using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Citizen : MonoBehaviour
{
    private CitizenStateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public CitizenPath Path;
    private Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] private GameObject playerArmature;
    private Animator playerAnimator;
    public Animator PlayerAnimator { get => playerAnimator; }

    private bool arrested = false; // for prototyping / testing

    void Start()
    {
        stateMachine = GetComponent<CitizenStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerAnimator = playerArmature.GetComponent<Animator>();
        stateMachine.Initialise();
    }

    // For prototyping / testing
    public void ArrestDearrest()
    {
        if (arrested) {
            Dearrest();
        } else {
            Arrest();
        }
    }

    public void Arrest()
    {
        arrested = true;
        stateMachine.ChangeState(stateMachine.arrestingState);
    }

    public void Dearrest()
    {
        arrested = false;
        stateMachine.ChangeState(null);
    }
}
