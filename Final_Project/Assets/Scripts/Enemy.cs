using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float fireDelay = 1f;
    public float attackDistance = 5f;
    public UnityEvent OnFire;

    private float lastFired;
    private GameObject player;
    private GameObject target;
    private NavMeshAgent navMeshAgent;
    private int wavepointIndex = 0;
    private Transform targets;

    public void Fire()
    {
        lastFired = Time.time;
        OnFire.Invoke();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            if (Time.time > lastFired + fireDelay)
            {
                Fire();
            }

            if (navMeshAgent.destination != target.transform.position)
                navMeshAgent.destination = target.transform.position;

            if (Vector3.Distance(target.transform.position, transform.position) > attackDistance)
            {
                target = null;
                GetComponent<Agent>().enabled = true;
            }

        }
        else
        {
            if (Vector3.Distance(player.transform.position, transform.position) < attackDistance)
            {
                target = player;

                GetComponent<Agent>().enabled = false;

                navMeshAgent.destination = target.transform.position;
            }
        }
    }

}
