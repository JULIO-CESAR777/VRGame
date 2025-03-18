using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public GameObject player; // Asigna el jugador en el Inspector
    private Transform playerPosition;
    public float rotationSpeed = 5f; // Velocidad de giro


    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        playerPosition = player.transform;
        if (player != null)
        {
            navAgent.SetDestination(playerPosition.position);
            RotateTowardsPlayer(); // Corrige la rotación
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        direction.y = 0; // Evita que el zombie se incline hacia arriba o abajo

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
