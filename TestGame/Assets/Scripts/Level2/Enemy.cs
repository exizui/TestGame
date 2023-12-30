using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    int i;
    public List<Transform> targets;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void TargetUpdate()
    {
        i = Random.Range(0, targets.Count);
    }
    void Update()
    {
        if (agent.transform.position == agent.pathEndPosition)
        {
            TargetUpdate();
        }

        agent.SetDestination(targets[i].position);
    }
}
