using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolScript : StateMachineBehaviour
{

    private int count = 0;
    public NavMeshAgent _navMeshA;
    private bool reached = true;
    private Vector3 newpos;
    private GameObject pat1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        _navMeshA = animator.GetComponent<NavMeshAgent>();
        count = 0;
        pat1 = GameObject.FindGameObjectWithTag("pat1");
        reached = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        


        if (count == 0 && reached)
        {
            newpos = pat1.transform.position;
            Debug.Log(newpos);
           
            reached = false;
            count++;
        }

        if (count == 1 && reached)
        {
            newpos = new Vector3(25, 0, -25);
            _navMeshA.SetDestination(newpos);
            reached = false;
            count=0;
        }

        _navMeshA.SetDestination(newpos);

        if (Vector3.Distance(_navMeshA.transform.position, newpos)<0.5)
        {
            reached = true;
            Debug.Log("done");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {


            animator.SetBool("isFollowing", true);
            animator.SetBool("isPatrolling", false);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {

            
            animator.SetBool("isPatrolling", false);
        }

    }

    







// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
