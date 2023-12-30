using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    float timer;
    List<Transform> points = new List<Transform>();
    private Transform player;
    NavMeshAgent agent;
    private float chaseRange = 10;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObjects = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform t in pointsObjects)
            points.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(points[Random.Range(0, points.Count)].position);
        timer += Time.deltaTime;
        if(timer > 10)
            animator.SetBool("IsPatrolling", false);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if(distance < chaseRange)
            animator.SetBool("IsChasing", true);
    }   

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
