using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    // Tiempo de espera entre ataques
    public float damageCooldown = 1f;
    private bool canDamage = true;

    // Tiempo de espera después de entrar al estado de ataque
    public float waitBeforeAttack = 1f;

    // Referencia al Animator del padre
    private Animator parentAnimator;

    private void Start()
    {
        // Obtener el Animator del objeto padre
        parentAnimator = GetComponentInParent<Animator>();
        canDamage = true;
    }

    // Método que se llama cuando otro collider entra en el trigger de este objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisionamos es el jugador y si podemos hacer daño
        if (other.CompareTag("Player") && canDamage)
        {
            // Verificamos si el zombie está en estado de ataque
            if (parentAnimator.GetBool("isAtacking"))
            {
                // Iniciamos la espera antes de hacer daño
                StartCoroutine(WaitBeforeDamage(other));
            }
        }
    }

    // Coroutine para esperar antes de hacer daño al jugador
    private IEnumerator WaitBeforeDamage(Collider player)
    {
        canDamage = false;
        // Espera el tiempo especificado
        yield return new WaitForSeconds(waitBeforeAttack);

        // Ahora que ha pasado el tiempo de espera, hacer daño al jugador
        GameManager.instance.DmgPlayer(25);

        // Iniciamos la espera para poder hacer daño de nuevo
        StartCoroutine(DamageCooldown());
    }

    // Coroutine que espera un segundo antes de permitir hacer daño de nuevo
    private IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
