using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int healthPoints = 100;
    private Animator animator;
    private NavMeshAgent navAgent;
    private ZombieFollow zombieFollow; // Referencia al script de movimiento

    void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        zombieFollow = GetComponent<ZombieFollow>(); // Obtener el componente
    }

    public void TakeDamage(int DamageAmount)
    {
        healthPoints -= DamageAmount;
        GameManager.instance.ChangePointsText(30);
        if (healthPoints <= 0)
        {
            Invoke("DestruirEnemy", 4.0f);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;

            // Detener el movimiento del zombie
            navAgent.acceleration = 0;
            if (zombieFollow != null)
            {
                zombieFollow.Die(); // Notificar al script de movimiento
            }

            // Seleccionar una animación de muerte aleatoria
            int randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }
        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }

    private void DestruirEnemy()
    {
        Destroy(gameObject);
    }

 


}
