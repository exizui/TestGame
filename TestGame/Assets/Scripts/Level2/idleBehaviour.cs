using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{
   float timer;
   private Transform player;
   private float chaseRange = 10;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       timer += Time.deltaTime;
       if(timer > 5)
        animator.SetBool("IsPatrolling", true); 
       
       float distance = Vector3.Distance(animator.transform.position, player.position);
       if(distance < chaseRange)
           animator.SetBool("IsChasing", true);
    }

   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
}
