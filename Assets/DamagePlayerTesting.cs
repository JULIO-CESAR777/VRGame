using UnityEngine;
using System.Collections;

public class DamagePlayerTesting : MonoBehaviour
{
    private Animator zombieAnimator;  // Referencia al Animator del zombie
    private bool canAttack = true;    // Control para verificar si el zombie puede atacar
    public float attackCooldown = 1f; // Tiempo de espera entre ataques (1 segundo)

    private void Start()
    {
        // Busca el Animator en el padre del objeto (asumiendo que la esfera está como hijo del zombie)
        zombieAnimator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("La esfera golpeó al jugador.");

            // Verifica si el zombie está en estado de ataque antes de hacer daño
            if (zombieAnimator != null && zombieAnimator.GetBool("isAtacking"))
            {
                // Llama al método de daño en el GameManager
                GameManager.instance.DmgPlayer(25);
                Debug.Log("Haciendo daño al jugador.");

                // Inicia el cooldown solo si no está en proceso de cooldown
                if (canAttack)
                {
                    StartCoroutine(AttackCooldown());
                }
            }
            else
            {
                Debug.Log("El zombie no está atacando, no se hace daño.");
            }
        }
    }

    // Corutina para esperar el tiempo de cooldown entre ataques
    private IEnumerator AttackCooldown()
    {
        canAttack = false; // Desactiva el ataque
        yield return new WaitForSeconds(attackCooldown); // Espera durante el cooldown
        canAttack = true; // Permite el siguiente ataque
    }
}
