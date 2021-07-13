using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunBehaviour : StateMachineBehaviour
{

    public NavMeshAgent _navMesh;
    private Transform PlayerPos;
    private Transform NPCPos;
    public NavMeshAgent playerNav;
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        NPCPos = GameObject.FindGameObjectWithTag("NPC").transform;
        playerNav = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();

        _navMesh = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        {

            float distP = Vector3.Distance(PlayerPos.position, _navMesh.transform.position);
            float distNPC = Vector3.Distance(NPCPos.position, _navMesh.transform.position);
            List<Transform> tforms = getNeighborsTransforms();
            Vector3 allignment = AlignmentMove(tforms);
            Vector3 avoidance = AvoidanceMove(tforms);
            Vector3 cohesion = CohesionMove(tforms);
            Vector3 vecs = avoidance + cohesion;
            int elems = 2; 

            if (distP < 6 )
            {
                
                Debug.Log("cerca");
                vecs +=  animator.transform.position - PlayerPos.position;
                elems++;
                vecs /= elems;

                Vector3 newPos = animator.transform.position + vecs;
                _navMesh.SetDestination(newPos);
            }

            if (distNPC < 6) {

                vecs += animator.transform.position - NPCPos.position;
                elems++;
                vecs /= elems;
                Vector3 newPos = animator.transform.position + vecs;
                _navMesh.SetDestination(newPos);
            }


           
              //  Vector3 vecs = (allignment + dirToPlayer + avoidance+ cohesion) / 4;
                
                    
                    
                //Vector3 newPos =  animator.transform.position + vecs;





                //_navMesh.SetDestination(newPos);
            

            
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    public List<Transform> getNeighborsTransforms()
    {

        List<Transform> context = new List<Transform>();

        Collider[] sorroundings = Physics.OverlapSphere(_navMesh.transform.position, 10);

        

        for (int i = 0; i<sorroundings.Length; i++)
        {
            if (sorroundings[i].gameObject.tag == "flockAgent" && sorroundings[i].transform != _navMesh.transform)
            {
                context.Add(sorroundings[i].gameObject.transform);
            }
        }

        return context;
        
    }


    public Vector3 AlignmentMove(List<Transform> transforms)
    {

        Vector3 alignmentPos = new Vector3();

        foreach(Transform trans in transforms)
        {
            alignmentPos += trans.position;
        }

        alignmentPos /= transforms.Count;
        return alignmentPos;


    }

    public Vector3 AvoidanceMove(List<Transform> transforms)
    {

        Vector3 avoPos = new Vector3();
        int avocount = 0;
       
    
         foreach (Transform trans in transforms)
         {

            if(Vector3.Distance(trans.position,_navMesh.transform.position) > 2)
            {
                avocount++;
                avoPos += (_navMesh.transform.position - trans.position);

            }
            avoPos += trans.position;
         }
        if (avocount > 0)
        {
            avoPos /= transforms.Count;
        }
        
        return avoPos;


    }

    public Vector3 CohesionMove(List<Transform> transforms)
    {

        Vector3 cohPos = new Vector3();

        foreach (Transform trans in transforms)
        {
            cohPos += trans.position;
        }

        cohPos /= transforms.Count;

        cohPos -= _navMesh.transform.position;
        return cohPos;


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
