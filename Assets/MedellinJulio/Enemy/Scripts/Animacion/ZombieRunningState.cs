using UnityEngine;
using UnityEngine.AI;

public class ZombieRunningState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public float chaseSpeed = 4f;

    public float stopChasingDistance = 26;
    public float attackingDistance = 2.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = chaseSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        // Si está dentro del rango, persigue al jugador
        if (distanceFromPlayer <= stopChasingDistance)
        {
            agent.SetDestination(player.position);
            animator.transform.LookAt(player);
        }
        else
        {
           
         
            animator.SetBool("isPatroling", true);
        }

        if (distanceFromPlayer < attackingDistance)
        {
            animator.SetBool("isAtacking", true);
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }

}
