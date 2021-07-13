using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : StateMachineBehaviour

  
{
    public NavMeshAgent _navMesh;
    private Transform PlayerPos;
    private Transform NPCPos;
    public NavMeshAgent playerNav;
    private GameObject[] enemyFlock;
    private GameObject objective;
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        NPCPos = GameObject.FindGameObjectWithTag("NPC").transform;
        playerNav = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        _navMesh = GameObject.FindGameObjectWithTag("NPC").GetComponent<NavMeshAgent>();
        enemyFlock = GameObject.FindGameObjectsWithTag("flockAgent");

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        float distance = Vector3.Distance(enemyFlock[0].transform.position, animator.transform.position);

        foreach (GameObject enemy in enemyFlock)
        {
           if(Vector3.Distance(enemy.transform.position, animator.transform.position) < distance)
            {
                objective = enemy;
                distance = Vector3.Distance(enemy.transform.position, animator.transform.position);
            }
        }


        _navMesh.SetDestination(objective.transform.position);




       // Debug.Log("tick");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
           
            animator.SetBool("isFollowing", false);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {

            animator.SetBool("isPatrolling", true);
            animator.SetBool("isFollowing", false);
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
