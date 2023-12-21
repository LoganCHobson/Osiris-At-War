using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemyState //Make the states inherit from this. Basically will force that script to have these functions. If it dont it dont work.
{
    void Enter(MapAIStateMachine stateMachine);
    void Run();
    void Exit();
}

public class MapAIStateMachine : MonoBehaviour //Dont touch this script.
{
    public Animator anim;
    [HideInInspector]
    public IEnemyState currentState; //DONT TOUCH 

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        SetState(gameObject.GetComponent<MapAIIdleState>());
    }

    private void Update()
    {
        if (!agent.isStopped)
        {
            currentState.Run();
        }
        else
        {
            currentState.Exit();
        }

        if (currentState == null)
        {
            SetState(gameObject.GetComponent<MapAIIdleState>());
        }

    }

    public void SetState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }


    public void AIStop(bool _value)
    {
        agent.isStopped = _value;
        Debug.Log("Agent isStopped = " + _value);
    }


}
