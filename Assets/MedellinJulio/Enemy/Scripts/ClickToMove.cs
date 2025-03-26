using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public GameObject player; // Asigna el jugador en el Inspector
    private Transform playerPosition;
    public float rotationSpeed = 5f; // Velocidad de giro
    public bool isAlive = true; // Controla si el zombie está vivo

    public GameObject itemPrefab; // Prefab del objeto que se dropea
    public float dropChance = 0.2f; // Probabilidad de dropear el objeto (20% por defecto)

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!isAlive) // Si el zombie está muerto, detiene el movimiento
        {
            navAgent.isStopped = true;
            return;
        }

        if (player != null)
        {
            playerPosition = player.transform;
            navAgent.SetDestination(playerPosition.position);
            RotateTowardsPlayer();
        }
    }

    void RotateTowardsPlayer()
    {
        Vector3 direction = (playerPosition.position - transform.position).normalized;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    // Método para detener el movimiento al morir y dropear un objeto
    public void Die()
    {
        isAlive = false;
        navAgent.isStopped = true; // Detiene el NavMeshAgent

        // Comprobar si el zombie debe dropear un objeto
        DropItem();
    }

    // Método para manejar el drop de un objeto con una probabilidad
    private void DropItem()
    {
        float randomChance = Random.Range(0f, 1f); // Genera un valor aleatorio entre 0 y 1
        if (randomChance <= dropChance) // Si el valor es menor o igual a la probabilidad de drop
        {
            // Instancia el objeto en la posición del zombie
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
