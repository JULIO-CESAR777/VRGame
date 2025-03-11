using UnityEngine;
using UnityEngine.AI;

public class ZombieAtackState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;

    public float stopAttackingDistance = 4f; // Distancia a la que el zombie se detiene para atacar
    public float attackRange = 1f; // Rango mínimo de ataque para evitar que se acerque demasiado

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.isStopped = true; // Detiene el movimiento cuando entra en el estado de ataque
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        // Asegurar que el zombie mantenga una distancia mínima
        if (distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAtacking", false);
            agent.isStopped = false; // Permitir que el zombie vuelva a moverse
        }
       

        LookAtPlayer();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.isStopped = false; // Permitir que el zombie vuelva a moverse cuando salga del estado de ataque
    }

    void LookAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        direction.y = 0; // Mantener la rotación solo en el eje Y
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
    }
}
