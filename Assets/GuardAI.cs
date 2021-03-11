using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    public Transform[] guardRotation;

    int curPosition = 0;

    enum guardState {Patrol, Pursue};
    guardState currentState = guardState.Patrol;
    NavMeshAgent navMeshAgent;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().SetDestination(guardRotation[curPosition].position);
    }

    void SwitchToState(guardState newState)
    {
        switch (newState)
        {
            case guardState.Patrol:
                break;
            case guardState.Pursue:
                navMeshAgent.SetDestination(target.transform.position);
                break;
            default:
                break;
        }
        currentState = newState;
    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case guardState.Patrol:
                if (navMeshAgent.remainingDistance < 0.04f)
                { 
                    curPosition = (curPosition + 1) % guardRotation.Length;
                    navMeshAgent.SetDestination(guardRotation[curPosition].position);
                }
                break;
            case guardState.Pursue:
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            SwitchToState(guardState.Pursue);
        }
    }
}
