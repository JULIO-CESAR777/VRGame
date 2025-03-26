using UnityEngine;

public class DamagePlayerTesting : MonoBehaviour
{
    private Collider triggerCollider;  // Variable para almacenar el objeto que entra en el trigger

    // Función que se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Almacena el collider del objeto que entra en el trigger
        triggerCollider = other;
    }

    // Función pública que hará el daño al jugador (esta se llamará desde el evento de la animación)
    public void dañando()
    {
        // Verifica si el triggerCollider es válido y si el objeto es el jugador
        if (triggerCollider != null && triggerCollider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.DmgPlayer(25);  // Llama al método de daño en el GameManager
            Debug.Log("dañando al jugador");
        }
        else
        {
            Debug.Log("No se ha producido una colisión con el jugador.");
        }
    }
}
