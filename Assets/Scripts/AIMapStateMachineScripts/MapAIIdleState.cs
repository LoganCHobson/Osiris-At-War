using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapAIIdleState : MonoBehaviour, IEnemyState //Every state must inherit from here.
{
    private MapAIStateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject target;

    private Animator anim;

    public void Enter(MapAIStateMachine stateMachine) //First thing the state does.
    {
        anim = GetComponent<MapAIStateMachine>().anim;
        //Debug.Log("Entering Idle State");
        this.stateMachine = stateMachine;
        //Debug.Log("Entering Idle State");
        //agent = GetComponentInParent<NavMeshAgent>();
        agent = FindAnyObjectByType<NavMeshAgent>();


    }

    public void Run() //Good ol update
    {

    }

    public void Exit() //Last thing the state does before sending us wherever the user specified in update.
    {
        // Debug.Log("Exiting Idle State");

    }
}
