using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Transform[] waypoints;

    NavMeshAgent navMeshAgent;
    int index;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.destination = waypoints[0].position;

        index = 0;
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance < Mathf.Epsilon)
        {
            index++;

            if (index > waypoints.Length - 1)
                index = 0;

            navMeshAgent.destination = waypoints[index].position;
        }
    }
}
