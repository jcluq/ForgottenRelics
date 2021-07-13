using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : StateMachineBehaviour
{
    public float wanderRadius = 200;
    public float wanderTimer = 1000;
    private float timer ;
    private Vector3 dest;
    private bool first = true;

    private bool reached = true;

    public NavMeshAgent _navMeshA;
   // private Transform PlayerPos;
    private Transform NPCPos;
    //    OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("IdleBegin");
     //  PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        NPCPos = GameObject.FindGameObjectWithTag("NPC").transform;

        _navMeshA = GameObject.FindGameObjectWithTag("NPC").GetComponent<NavMeshAgent>();
        reached = true;
        _navMeshA.SetDestination(NPCPos.position);
        dest = RandomNavSphere(NPCPos.position, wanderRadius, -1);
     
             _navMeshA.SetDestination(dest);
        
        // timer = wanderTimer;
    }

   //  OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (first == false)
        {
            reached = true;
            dest = RandomNavSphere(NPCPos.position, wanderRadius, -1);
            first = true;
        }
        
        

        _navMeshA.SetDestination(dest);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed");
            animator.SetBool("isFollowing", true);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N");
            animator.SetBool("isPatrolling", true);
        }



            if (reached)
        {

            Debug.Log("Moving");
            dest = RandomNavSphere(NPCPos.position, wanderRadius, -1);
            _navMeshA.SetDestination(dest);
            reached = false;
        }

        if (!reached && dest == NPCPos.position)
        {
            reached = true;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }



//OnStateExit is called when a transition ends and the state machine finishes evaluating this state
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // first = false;
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
